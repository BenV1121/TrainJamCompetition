using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageTrigger : MonoBehaviour
{
    public float damageOnContact = 5.0f;
    public float damageOverTime = 4.0f;

    private List<IDamageable> occupants = new List<IDamageable>();

    public bool shouldIgnoreEnemy = false;

    private void OnTriggerEnter(Collider other)
    {
        IDamageable target = other.gameObject.GetComponent<IDamageable>();

        if (target == null) { return; }
        if (shouldIgnoreEnemy)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                return;
            }
        }
        target.TakeDamage(damageOnContact);
        occupants.Add(target);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Castle")
            damageOverTime -= Time.deltaTime;
    }

    private void OnTriggerExit(Collider other)
    {
        IDamageable target = other.gameObject.GetComponent<IDamageable>();

        if(target == null) { return; }

        occupants.Remove(target);

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Castle")
            damageOverTime = 4.0f;
    }
}
