using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControll : MonoBehaviour
{
    public Animator camAnim;
    public Animator textAnim;
    public static GameControll instance;
    public bool gameOver = false;
    public int score = 0;
    public Text scoreText;
    public Text yourScoreText;
    public Text highScoreText;
    public Text yourScoreText1;
    public Text highScoreText1;
    public float shrinkSpeed = 3f;

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
    }

    void Start()
    {
        highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        yourScoreText.text = "YOUR SCORE: " + PlayerPrefs.GetInt("Current", 0).ToString();
        highScoreText1.text = highScoreText.text;
        yourScoreText1.text = yourScoreText.text;
    }

    public void PlayerDied()
    {
        gameOver = true;
    }

    public void PlayerScored() 
    {
        if (gameOver)
        {
            return;
        }
        score++;
        camAnim.SetTrigger("Shake");
        scoreText.text = score.ToString();
        yourScoreText.text = "YOUR SCORE: " + PlayerPrefs.GetInt("Current", score).ToString();
        yourScoreText1.text = yourScoreText.text;
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "HIGH SCORE: " + score.ToString();
            highScoreText1.text = highScoreText.text;
        }
    }

}
