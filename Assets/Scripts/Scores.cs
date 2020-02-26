using UnityEngine;

public class Scores : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player> () != null)
        {
            GameControll.instance.PlayerScored();
        }
    }
}
