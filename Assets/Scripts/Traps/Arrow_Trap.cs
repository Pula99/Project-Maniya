using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Trap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;

  //  [SerializeField] private AudioClip Sound;

    private float cooldownTimer;

    private void Attack()
    {
        cooldownTimer = 0;
       // SoundManager.instance.PlaySound(Sound);
        arrows[FindArrow()].transform.position = firePoint.position;
        arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= attackCooldown)
            Attack();
    }

    
}

