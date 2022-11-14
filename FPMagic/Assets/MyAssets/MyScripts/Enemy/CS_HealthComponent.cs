using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_HealthComponent : MonoBehaviour
{
    //Make Scriptable Object for Enemy
    [SerializeField]  private float maxHealth = 50f;
    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageToApply)
    {
        currentHealth -= damageToApply;
        if (currentHealth <= 0) Destroy(this.gameObject);
    }
}
