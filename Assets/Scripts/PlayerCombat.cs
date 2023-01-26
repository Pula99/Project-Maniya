using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject ninjastarprefab;
    [SerializeField] private float PlayerShootDamage;
    
    void Update()
    {
     
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(ninjastarprefab, firepoint.position, firepoint.rotation);
    }
}
