using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public float speed;
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(new Vector3 (20, 0, 0) * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TrainDestroyer")
        {
            Destroy(gameObject);
        }
    }
}
