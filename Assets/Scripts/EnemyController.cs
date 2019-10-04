using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{

    private Transform player;
    private NavMeshAgent agent;

    public bool alive = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

    } // end Start

    public void kill()
    {
        alive = false;
    }

    void Update()
    {
        if(alive == true) {
	        agent.destination = player.transform.position;
	        Vector3 lookatpos = player.position;
	        lookatpos.y = 0;
	        gameObject.transform.LookAt(lookatpos);
    	}


    } // end Update
} // end BasicController02