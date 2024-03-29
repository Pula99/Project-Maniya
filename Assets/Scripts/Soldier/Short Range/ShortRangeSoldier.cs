using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortRangeSoldier : MonoBehaviour
{ 

    [Header("Enemy Attack Parameter")]
    [SerializeField] private float attackCooldown;
    [SerializeField] public int damage;
    [SerializeField] private float range;

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

    [Header("Enemy Attack Sound")]
    [SerializeField] private AudioClip AttackSound;

    [Header("Enemy Death Sound")]
    [SerializeField] private AudioClip DeathSound;
    [SerializeField] private AudioClip HurtSound;

    //references
    private Animator anim;
    private PlayerHealth playerHealth;
    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }


    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //attack when player only in sight

        if (PlayerInSight())
        {
            if(cooldownTimer >= attackCooldown)
            {
                
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
                SoundManager.instance.PlaySound(AttackSound);
            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();


    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, PlayerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<PlayerHealth>();

        return hit.collider != null;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance ,
           new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }




    private void DamagePlayer()
    {
        // if player still in the range damage
        if (PlayerInSight())
        {
           
            playerHealth.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Manager.instance.PlayerHealth.TakeDamage(damage);
        }
    }

    void Start()
    {
        currentHealth = maxHealth;

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        SoundManager.instance.PlaySound(HurtSound);
        anim.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            anim.SetTrigger("die");
            SoundManager.instance.PlaySound(DeathSound);
            Die();

        }
    }

    void Die()
    {
        
        if (deathEffect)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        Destroy(enemyPatrol.gameObject, 1f);
    }

}
