
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
        SoundManager.instance.PlaySound(gameOverSound);
    }

    public void GameWin()
    {
        gameWinScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameWinSound);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);

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
