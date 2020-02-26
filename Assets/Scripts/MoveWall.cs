using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public Rigidbody2D rb;
    public float shrinkSpeed = 3f;

  void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, shrinkSpeed * 0.86f * Time.deltaTime);
        if (transform.position == Vector3.zero)
        {
            Destroy(gameObject);
        }
    }
}
