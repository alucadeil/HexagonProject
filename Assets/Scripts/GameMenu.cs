using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject gameOverMenu;
    public GameObject inGameMenu;


    void Update()
    {
        if (GameControll.instance.gameOver)
        {
            gameOverMenu.SetActive(true);
            inGameMenu.SetActive(false);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }
    }

    public  void ResumeDied()
    {
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameControll.instance.gameOver = false;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
