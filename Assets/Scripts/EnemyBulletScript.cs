using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyBulletScript : MonoBehaviour
{
    [SerializeField] public GameObject player;
    private Rigidbody2D rb;

    [Header("bullet stats")]
    [SerializeField] public float speed;
    [SerializeField] private float bulletVanishTime;
    [SerializeField] private float damage = 10; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

      /*  float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);*/
    }

    // Update is called once per frame
    void Update()
    {
        bulletVanishTime += Time.deltaTime;

        if (bulletVanishTime > 10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        Destroy(gameObject);

    }

}
