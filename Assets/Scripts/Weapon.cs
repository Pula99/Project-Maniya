using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject ninjastarprefab;
    
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
