using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour
{
    public new GameObject camera;

    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(transform.position + camera.transform.rotation * Vector3.forward,
            camera.transform.rotation * Vector3.up);
	}
}
