using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform respawnPoint;

    public PlayerHealth PlayerHealth { get => playerHealth; set => playerHealth = value; }
    public GameObject Player { get => player; set => player = value; }
    public Transform RespawnPoint { get => respawnPoint; set => respawnPoint = value; }

    void Awake()
    {
        instance = this;
    }

}
