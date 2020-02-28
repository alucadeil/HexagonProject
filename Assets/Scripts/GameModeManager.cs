using UnityEngine;
using UnityEngine.SceneManagement;


public class GameModeManager : MonoBehaviour
{
    public static GameModeManager instance;
    public float[] cameraSpeed;
    public float[] spawnRate;
    public float[] addSpeed;
    public int[] spawnCount;
    public int[] scoreToWin;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        cameraSpeed = new float[3] {15f, 30f, 35f};
        spawnRate = new float[3] {1f, 1.5f, 1.8f};
        addSpeed = new float[3] {0.005f, 0.005f, 0.005f};
        scoreToWin = new int[3] {50, 50, 50};
        spawnCount = new int[3] {2, 3, 3};
        DontDestroyOnLoad(gameObject);
    }

    public void GameMode(int index)
    {
        GameMenu.gameIsPaused = false;
        Time.timeScale = 1f;
        Rotator.rotateSpeed = cameraSpeed[index];
        SpawnLines.spawnSpeedUp = addSpeed[index];
        SpawnLines.spawnRate = spawnRate[index];
        SpawnLines.numberOfWalls = spawnCount[index];
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
