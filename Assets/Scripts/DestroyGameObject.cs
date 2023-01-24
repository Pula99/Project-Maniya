using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    [Tooltip("Time to destroy gameobject from instantiate")]
    [SerializeField] private float destroyTime = 1f;
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
