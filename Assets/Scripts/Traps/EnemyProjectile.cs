using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{/*
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    public void ActivateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);

    }

    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.tag == "Player")
        {
            Manager.instance.PlayerHealth.TakeDamage(damage);
        }

        gameObject.SetActive(false);
    }*/


    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    private Animator anim;
    private BoxCollider2D coll;

    [Header("Player Death Sound")]
    [SerializeField] private AudioClip ExplodeSound;

    private bool hit;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;


        if (collision.tag == "Player")
          
            Manager.instance.PlayerHealth.TakeDamage(damage);
     
         

        coll.enabled = false;


        if (anim != null)
        {
            anim.SetTrigger("explode"); //When the object is a fireball explode it

            if(ExplodeSound)
                SoundManager.instance.PlaySound(ExplodeSound);
           
        }
        else
        {   
            gameObject.SetActive(false);

            if(ExplodeSound)
                SoundManager.instance.PlaySound(ExplodeSound);
        }//When this hits any object deactivate arrow
           
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
       
    }

}

