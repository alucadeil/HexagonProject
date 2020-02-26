using UnityEngine;

public class Player : MonoBehaviour
{
    void OnCollisionEnter2D () 
    {
        GameControll.instance.PlayerDied();
    }
}
