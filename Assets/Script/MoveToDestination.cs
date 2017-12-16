using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToDestination : MonoBehaviour
{
    public Transform castle;
    Vector3 destination;
    NavMeshAgent agent;

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        castle = GameObject.FindGameObjectWithTag("Castle").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        destination = castle.position;
        agent.destination = destination;
	}
}
