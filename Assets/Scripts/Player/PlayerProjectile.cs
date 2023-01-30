using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private float lifeTime;
    [SerializeField] private int damage = 40;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject ImpactEffect;

    private Animator anim;
    private CircleCollider2D circleCollider;

    private void Start()
    {
        rb.velocity = transform.right * speed;
    }


    private void Awake()
    {
        anim = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
       
    }
    
    void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > 5)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        circleCollider.enabled = false;
        anim.SetTrigger("hit");

        Enemy enemy = collision.GetComponent<Enemy>();
        ShortRangeSoldier srSoldier = collision.GetComponent<ShortRangeSoldier>();
        LongRangeSoldier lrSoldier = collision.GetComponent<LongRangeSoldier>();
        EnemyFollowPlayer efSoldier = collision.GetComponent<EnemyFollowPlayer>();
        FollowingEliteEnemyBullet feeSoldier = collision.GetComponent<FollowingEliteEnemyBullet>();
        Canon canonBall = collision.GetComponent<Canon>();
        DoomsDay DD = collision.GetComponent<DoomsDay>();



        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if (srSoldier != null)
        {
            srSoldier.TakeDamage(damage);
        }

        if (lrSoldier != null)
        {
            lrSoldier.TakeDamage(damage);
        }

        if (efSoldier != null)
        {
            efSoldier.TakeDamage(damage);
        }

        if (feeSoldier != null)
        {
            feeSoldier.TakeDamage(damage);
        }

        if (canonBall != null)
        {
            canonBall.TakeDamage(damage);
        }

        if (DD != null)
        {
            DD.TakeDamage(damage);
        }






        if (ImpactEffect)
        {
            Instantiate(ImpactEffect, transform.position, transform.rotation);

        }

        Destroy(gameObject);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
