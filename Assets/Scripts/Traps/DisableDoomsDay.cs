using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDoomsDay : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform previousArea;
    [SerializeField] private Transform newArea;
    //[SerializeField] private CameraController cam;
    private Vector3[] intialPosition;

    private void Awake()
    {
        //save the initial position of the enemies
        intialPosition = new Vector3[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
                intialPosition[i] = enemies[i].transform.position;
        }
    }

    public void ActivateArea(bool _status)
    {
        //activate and deactivate enemies
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {

                enemies[i].SetActive(_status);
                enemies[i].transform.position = intialPosition[i];
                
            }
        }
    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            {
                newArea.GetComponent<DisableDoomsDay>().ActivateArea(true);
                previousArea.GetComponent<DisableDoomsDay>().ActivateArea(false);
            }
            else
            {
                previousArea.GetComponent<DisableDoomsDay>().ActivateArea(true);
                newArea.GetComponent<DisableDoomsDay>().ActivateArea(false);
            }
        }
    }*/
}
