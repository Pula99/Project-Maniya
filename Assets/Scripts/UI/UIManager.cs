using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject gameWinScreen;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip gameWinSound;


    private void Awake()
    {
        gameOverScreen.SetActive(false);
        gameWinScreen.SetActive(false);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
       // SoundManaager.instance.PlaySound(gameOverSound);
    }

    public void GameWin()
    {
        gameWinScreen.SetActive(true);
        // SoundManger.instance.PlaySound(gameWinSound);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void MainMenue()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
