using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float damage;
    private Rigidbody2D rb;
    [SerializeField] public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Manager.instance.PlayerHealth.TakeDamage(damage);
            Destroy(gameObject);
    }

}
