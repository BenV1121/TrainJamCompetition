﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CastleHP : MonoBehaviour, IDamageable
{
    public float healthValue = 100;

    public bool isDead = false;

    public Image hp;

    void Start()
    {
        hp = GameObject.FindGameObjectWithTag("CHP").GetComponent<Image>();
    }

    public float EstimatedDamageTaken(float damageDealt)
    {
        return damageDealt;
    }

    public void TakeDamage(float damageDealt)
    {
        healthValue -= damageDealt;
        if (healthValue <= 0)
        {
            Death();
        }
    }

    // Update is called once per frame
    void Update()
    {
        hp.fillAmount = healthValue / 100;

        if (isDead)
        {
            Destroy(transform.parent.gameObject);
            SceneManager.LoadScene("Test");
        }
    }

    void Death()
    {
        isDead = true;
    }
}