using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public new GameObject camera;

    public float Force = .05f;
    public float JumpForce;

    private bool isSprint = false;

    public float xForce;
    public float yForce;
    public float jump;

    public bool canMove = true;
    public bool canDash;
    public bool groundCheck = true;

    private Rigidbody pRigidbody;

    static Animator anim;

    // Use this for initialization
    void Start ()
    {
        pRigidbody = gameObject.GetComponent<Rigidbody>();
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        if(!canMove)
        {
            return;
        }
        canDash = true;

        transform.rotation = Quaternion.Euler(0, camera.GetComponent<CameraScript>().currentYRotation, 0);

		if(Input.GetKey(KeyCode.LeftShift))
        {
            isSprint = true;
        }

        xForce = Input.GetAxis("Horizontal") * Force;
        yForce = Input.GetAxis("Vertical") * Force;

        transform.Translate(new Vector3(0, jump, 0));

        if (isSprint != true)
        {
            transform.Translate(new Vector3(xForce, 0, yForce * 2));
        }
        else
        {
            transform.Translate(new Vector3(xForce * 2f, 0, yForce * 2));

        }
        isSprint = false;

        if (Input.GetKeyDown(KeyCode.Space) && groundCheck)
        {
            pRigidbody.AddForce(Vector3.up * 300);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }

    void OnCollisionEnter(Collision other)
    { groundCheck = true; }


    void OnCollisionStay(Collision other)
    { groundCheck = true; }

    void OnCollisionExit(Collision other)
    { groundCheck = false; }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Train")
        {
            if (Input.GetKey(KeyCode.E))
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                Destroy(other.gameObject);
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Train")
        {
            if (Input.GetKey(KeyCode.E))
            {
                gameObject.transform.GetChild(3).gameObject.SetActive(true);
                Destroy(other.gameObject);
            }
        }
    }
}
