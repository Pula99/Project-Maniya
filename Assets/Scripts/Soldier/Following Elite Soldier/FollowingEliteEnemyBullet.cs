using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEliteEnemyBullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] public float speed = 5;
    Transform player;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] public int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Manager.instance.PlayerHealth.TakeDamage(damage);
        Destroy(gameObject);
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
       
        Destroy(gameObject);
    }


}
