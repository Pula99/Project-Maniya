using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!triggered)
            {
                //trigger the firetrap
            }

            if (active)
                collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    private IEnumerator ActivateFiretrap()
    {
        triggered = true;
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(activateDelay);
        spriteRend.color = Color.white;
        active = true;
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
    }
}
