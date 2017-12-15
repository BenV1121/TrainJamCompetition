using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject prefabSpawn;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Train")
        {
            Debug.Log("Spawn yo");
            prefabSpawn = Instantiate(prefabSpawn, spawnLocations[0].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
        }
    }
}
