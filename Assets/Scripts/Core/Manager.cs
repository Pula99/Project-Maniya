using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameObject player;

    public PlayerHealth PlayerHealth { get => playerHealth; set => playerHealth = value; }
    public GameObject Player { get => player; set => player = value; }

    void Awake()
    {
        instance = this;
    }

}
