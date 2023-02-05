using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    [SerializeField] public int damage;
    //  public GameObject gun;

    [Header("Enemy Death Sound")]
    [SerializeField] private AudioClip DeathSound;
    [SerializeField] private AudioClip HurtSound;

    private Animator anim;

    [Header("Enemy life")]
    [SerializeField] private int maxHealth = 100;
    public int currentHealth;
    [SerializeField] public GameObject deathEffect;


    [SerializeField] private UnityEvent onEnterEvent;
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if(distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            onEnterEvent?.Invoke();


        }

        else if (distanceFromPlayer <= shootingRange && nextFireTime <Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        SoundManager.instance.PlaySound(HurtSound);
        anim.SetTrigger("hurt");
        

        if (currentHealth <= 0)
        {
          
            anim.SetTrigger("death");
            SoundManager.instance.PlaySound(DeathSound);
            Die();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Manager.instance.PlayerHealth.TakeDamage(damage);
        }
    }

    void Die()
    {
        /* if (deathEffect)
         {
             Instantiate(deathEffect, transform.position, Quaternion.identity);

         }*/
       
        Destroy(gameObject,4f);
    }


}


