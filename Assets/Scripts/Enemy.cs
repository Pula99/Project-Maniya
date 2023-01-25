using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private GameObject deathEffect;

    


    void Start()
    {
        currentHealth = maxHealth;
        
    }

    public void TakeDamage ( int damage )  
    {
        currentHealth -= damage;
        

        if (currentHealth <= 0)
        {
            Die();
        }
        
    }

    void Die()
    {
        if (deathEffect)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);

        }
        Destroy(gameObject);
    }
}
