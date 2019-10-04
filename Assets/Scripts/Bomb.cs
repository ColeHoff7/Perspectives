using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bomb : MonoBehaviour {

	public GameObject explosion;

	public float explosionRadius = 5.0F;
    public float explosionPower = 10.0F;

    private GameObject fuse;
    private AudioSource boomSound;


	void Start()
    {
    	fuse = transform.Find("BombShape/Flame").gameObject;
    	fuse.SetActive(false);
    	boomSound = gameObject.GetComponent<AudioSource>();
    }

    public void ignite() {
    	fuse.SetActive(true);
    	StartCoroutine(blowUp());
    	boomSound.Play();
    }

    IEnumerator blowUp()
    {

        yield return new WaitForSeconds(3);
        
        GameObject boom = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(boom, 2);
        Destroy(gameObject.transform.GetChild(0).gameObject);
        Destroy(gameObject, 2);

        // apply explosion
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            NavMeshAgent agent = hit.GetComponent<NavMeshAgent>();

            if (agent != null) Destroy(agent);

            if (rb != null){
            	rb.constraints = RigidbodyConstraints.None;
            	hit.GetComponent<EnemyController>().kill();
                rb.AddExplosionForce(explosionPower, explosionPos, explosionRadius, 4.0F);
                rb.AddTorque(Vector3.Normalize(Quaternion.Euler(0, 90, 0) * (hit.transform.position - transform.position)) * 40.0f);
            }
            else if (hit.gameObject.tag == "Player") {

            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
