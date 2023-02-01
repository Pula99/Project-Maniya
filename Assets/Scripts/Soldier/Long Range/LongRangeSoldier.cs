using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeSoldier : MonoBehaviour
{
    [Header("Enemy Attack Parameter")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float range;

    [Header("Range Attack")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] RangeBullet;

    [Header("Collider Parameter")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask PlayerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Enemy life")]
    [SerializeField] private int maxHealth = 100;
    public int currentHealth;
    [SerializeField] public GameObject deathEffect;

    //references
    private Animator anim;
    private LongEnemyPatrol longEnemyPatrol;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        longEnemyPatrol = GetComponentInParent<LongEnemyPatrol>();
    }


    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //attack when player only in sight

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("RangeAttack");
            }
        }

        if (longEnemyPatrol != null)
            longEnemyPatrol.enabled = !PlayerInSight();
    }

    private void RangeAttack()

    {
        if (PlayerInSight())
        {
            cooldownTimer = 0;
            RangeBullet[FindFireball()].transform.position = firepoint.position;
            RangeBullet[FindFireball()].GetComponent<EnemyProjectile>().ActivateProjectile();
        } 
    }

    
    private int FindFireball()
    {
        for (int i = 0; i < RangeBullet.Length; i++)
        {
            if (!RangeBullet[i].activeInHierarchy)
                return i;
        }
        return 0;
    }


    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, PlayerLayer);

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
           new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void OnTriggerEnter2D(CapsuleCollider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
        }
    }


    void Start()
    {
        currentHealth = maxHealth;

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            anim.SetTrigger("Die");
            Die();
        }

    }

    void Die()
    {
        if (deathEffect)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject,1f);
    }


}
