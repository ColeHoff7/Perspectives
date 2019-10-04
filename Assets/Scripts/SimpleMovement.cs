using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class SimpleMovement : NetworkBehaviour
{

    public float speed = 2.0F;
    public float runningSpeed = 3.0f;
    public float gravity = 20.0F;
    public float jumpSpeed = 6.0f;
    private Vector3 moveDirection = Vector3.zero;
    private bool wasJumping = false;
    private float startingY = 0.0f;


    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        float currentSpeed;
        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            currentSpeed = runningSpeed;
        else
            currentSpeed = speed;

        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= currentSpeed;
            if (wasJumping)
            {
                wasJumping = false;
            }
            if (Input.GetKeyDown(KeyCode.Space) && !wasJumping)
            {
                startingY = transform.position.y;
                moveDirection.y = jumpSpeed;
                wasJumping = true;
            }
        }
        if (Input.GetKey(KeyCode.Space) && transform.position.y < startingY + .5f && wasJumping)
        {
            moveDirection.y = jumpSpeed;
        }
        if(transform.position.y >= startingY + .5f)
        {
            wasJumping = false;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    //allows character to push objects
    public float pushPower = 2.0F;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3F)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * pushPower;
    }

}
