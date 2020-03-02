using UnityEngine;

public class Scores : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player> () != null)
        {
            GameControll.instance.PlayerScored();
            Destroy(gameObject);
        }
    }
}
