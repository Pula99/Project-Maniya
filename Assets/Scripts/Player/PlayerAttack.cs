using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject Bullets;
    [SerializeField] private AudioClip playerBulletSound;

    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && cooldownTimer > attackCooldown)
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        SoundManager.instance.PlaySound(playerBulletSound);
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        Instantiate(Bullets, firePoint.position, firePoint.rotation);

    }

}
