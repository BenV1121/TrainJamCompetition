using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface IDamageable
{
    float EstimatedDamageTaken(float damageDealt);

    void TakeDamage(float damageDealt);
}

public class Health : MonoBehaviour
{
    public float healthValue = 100;

    public bool isDead = false;

    public Image hp;

    bool damaged;

    public bool knockedBack;

	// Use this for initialization
	void Start ()
    {
        hp = GameObject.FindGameObjectWithTag("HP").GetComponent<Image>();
	}

    public float EstimatedDamageTaken(float damagDealt)
    {
        return damagDealt;
    }

    public void TakeDamage(float damageDealt)
    {
        healthValue -= damageDealt;

        if (hp.fillAmount <= 0)
        {
            Death();
        }
    }
	
	// Update is called once per frame
	public void Update ()
    {
        hp.fillAmount = healthValue / 100;

        damaged = false;

        if(isDead)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
	}

    void Death()
    {
        isDead = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HP")
        {
            if(healthValue<100)
            {

            }
        }
    }
}
