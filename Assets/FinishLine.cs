using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    public UIManager uiManager;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.BgSound.enabled = false;
            uiManager.GameWin();
           // Time.timeScale = 0;
        }
    }
    
}
