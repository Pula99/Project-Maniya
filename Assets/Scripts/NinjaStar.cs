using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStar : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private int damage = 40;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject ImpactEffect;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if (ImpactEffect)
        {
            Instantiate(ImpactEffect, transform.position, transform.rotation);

        }

        Destroy(gameObject);
    }
 
}
