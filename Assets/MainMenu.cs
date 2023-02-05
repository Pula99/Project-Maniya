using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetFloat("Health", 20);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetDifficulty(int level)
    {
        switch (level)
        {
            case 1:
                PlayerPrefs.SetFloat("Health", 30);
                break;
            case 2:
                PlayerPrefs.SetFloat("Health", 25);
                break;
            case 3:
                PlayerPrefs.SetFloat("Health", 20);
                break;
        }
    }

}
