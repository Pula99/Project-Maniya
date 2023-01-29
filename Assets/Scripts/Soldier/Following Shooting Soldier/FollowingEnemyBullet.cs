using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemyBullet : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private float damage;
    public float speed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(direction.x, direction.y);
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Manager.instance.PlayerHealth.TakeDamage(damage);
            Destroy(gameObject);
    }
}
