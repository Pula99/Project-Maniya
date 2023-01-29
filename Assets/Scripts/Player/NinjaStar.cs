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
        ShortRangeSoldier srSoldier = hitInfo.GetComponent<ShortRangeSoldier>();
        LongRangeSoldier lrSoldier = hitInfo.GetComponent<LongRangeSoldier>();
        EnemyFollowPlayer efSoldier = hitInfo.GetComponent<EnemyFollowPlayer>();
        FollowingEliteEnemyBullet feeSoldier = hitInfo.GetComponent<FollowingEliteEnemyBullet>();
        Canon canonBall = hitInfo.GetComponent<Canon>();
        DoomsDay DD = hitInfo.GetComponent<DoomsDay>();



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
 
}
