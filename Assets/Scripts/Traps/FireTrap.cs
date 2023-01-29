using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth playerHealth;


    [Header("Fire Timers")]
    [SerializeField] private float activateDelay;
    [SerializeField] private float activeTime;
    [SerializeField] private float damage;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered; //when the trap gets triggered
    private bool active; // when the trap is active and can hurt the player

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(playerHealth != null && active)
            Manager.instance.PlayerHealth.TakeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<PlayerHealth>();

            if (!triggered)
                StartCoroutine(ActivateFiretrap());

            if (active)
            Manager.instance.PlayerHealth.TakeDamage(damage);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            playerHealth = null;
    }

    private IEnumerator ActivateFiretrap()
    {
        //turn the sprite red to notify the player and trigger the trap
        triggered = true;
        spriteRend.color = Color.red;

        //wait for dealy,activate trap, turn on animation, return color back to normal
        yield return new WaitForSeconds(activateDelay);
        spriteRend.color = Color.white; // turn the sprite initial color back
        
        active = true;
        anim.SetBool("activated", true);

        //wait until x seconds, deactivate trap and reset all variables and animator
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
