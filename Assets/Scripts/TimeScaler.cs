
using UnityEngine;

public class TimeScaler : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        bool flag = PlayerRotation.flag;
        if (flag && !GameControll.instance.gameOver && !GameMenu.gameIsPaused)
        {
            Time.timeScale = 0.5f;
        } else if(!flag && !GameControll.instance.gameOver && !GameMenu.gameIsPaused)
        {
            Time.timeScale = 1f;
        }
    }
}
