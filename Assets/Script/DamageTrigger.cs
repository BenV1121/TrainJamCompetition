using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    public float damageOnContact = 5.0f;
    public bool isDamaging;

    private List<IDamageable> occupants = new List<IDamageable>();

    public bool shouldIgnorePlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        if(isDamaging)
        {
            IDamageable target = other.gameObject.GetComponent<IDamageable>();

            if(target == null) { return; }
            if(shouldIgnorePlayer)
            {
                if(other.gameObject.CompareTag("Player"))
                {
                    return;
                }
            }
            target.TakeDamage(damageOnContact);
            occupants.Add(target);
        }
    }

	
}
