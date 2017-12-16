using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    static Animator anim;
    public bool stillInAttackFrame;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("isAttacking1", true);
            if (stillInAttackFrame)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    anim.SetBool("isAttacking2", true);
                    if (stillInAttackFrame)
                    {
                        if (Input.GetButtonDown("Fire1"))
                        {
                            anim.SetBool("isAttacking3", true);
                        }
                        else
                        {
                            anim.SetBool("isAttacking3", false);
                        }
                    }
                }
                else
                {
                    anim.SetBool("isAttacking2", false);
                    anim.SetBool("isAttacking3", false);
                }
            }
        }
        else
        {
            anim.SetBool("isAttacking1", false);
            anim.SetBool("isAttacking2", false);
            anim.SetBool("isAttacking3", false);
        }
	}
}
