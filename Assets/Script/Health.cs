using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

interface IDamageable
{
    float EstimatedDamageTaken(float damageDealt);

    void TakeDamage(float damageDealt);
}

public class Health : MonoBehaviour, IDamageable
{
    public float healthValue = 100;

    public bool isDead = false;

    public Image hp;

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

        if(isDead)
        {
            SceneManager.LoadScene("Test");
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
