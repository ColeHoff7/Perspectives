using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
//ha
public class BasicController02 : NetworkBehaviour
{
    private Animator animator;
    private CharacterController controller;
    public float transitionTime = 0.25f;

    public AudioClip deathSound;

    Transform spawn;

    
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        if (animator.layerCount >= 2)
        {
            animator.SetLayerWeight(1, 1);
        }

        GameObject.Find("NetworkManager").GetComponent<NetworkManagerHUD>().showGUI = false;

        if (isLocalPlayer) {
            spawn = transform;
        }
    } // end Start
    void Update()
    {
        if(!isLocalPlayer) return;

    

        Vector3 moveDirection = Vector3.zero;
        float accelerator = 1.0f;
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
            {
                accelerator = 2.0f;
            }
            else if (Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.LeftAlt))
            {
                accelerator = 1.5f;
            }
            animator.SetBool("Jump", false);



            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            float xSpeed = h * accelerator;
            float zSpeed = v * accelerator;
            float speed = Mathf.Sqrt(h * h + v * v);
            animator.SetFloat("xSpeed", xSpeed, transitionTime, Time.deltaTime);
            animator.SetFloat("zSpeed", zSpeed, transitionTime, Time.deltaTime);
            animator.SetFloat("Speed", speed, transitionTime, Time.deltaTime);

            CmdUpdateAnimation(xSpeed, zSpeed, speed);

        }
        else
        {
            animator.SetBool("Jump", true);
        }

        if(transform.position.y < -45)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            transform.position = Vector3.zero;// spawn.position;
        }
            /*if (Input.GetKey(KeyCode.Space) && player.position.y < startingY + 1.0f)
            {
                moveDirection.y = jumpSpeed;
            }
            moveDirection.y -= 100.0f * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);*/

    } // end Update


    [Command]
    void CmdUpdateAnimation(float xSpeed, float zSpeed, float speed) {
        RpcUpdateAnimation(xSpeed, zSpeed, speed);
    }

    [ClientRpc]
    void RpcUpdateAnimation(float xSpeed, float zSpeed, float speed) {
        
        if(isLocalPlayer) return; // only run this for the other player, not yourself
        
        animator.SetFloat("xSpeed", xSpeed, transitionTime, Time.deltaTime);
        animator.SetFloat("zSpeed", zSpeed, transitionTime, Time.deltaTime);
        animator.SetFloat("Speed", speed, transitionTime, Time.deltaTime);
    }
} // end BasicController02
