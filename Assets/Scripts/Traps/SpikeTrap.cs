using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{

    [Header("spike stats")]

    [SerializeField] private float damage = 10;
    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            Manager.instance.PlayerHealth.TakeDamage(damage);
    }


}
