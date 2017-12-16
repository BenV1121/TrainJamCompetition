using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public float healthValue = 100;

    public bool isDead = false;

    bool damaged;

    public bool knockedBack;

    CameraScript cam;

    public float EstimatedDamageTaken(float damageDealt)
    {
        return damageDealt;
    }

    public void TakeDamage(float damageDealt)
    {

        healthValue -= damageDealt;
        if(healthValue <= 0)
        {
            Death();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(isDead)
        {
            Destroy(gameObject);
            cam = GetComponent<CameraScript>();

            cam.selectedTarget = null;
        }
	}

    void Death()
    {
        isDead = true;
    }
}
