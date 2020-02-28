using UnityEngine;

public class HexagonMovement : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public float shrinkSpeed = 3f;

    void Start()
    {
        transform.localScale = Vector3.one * 6.8f;   
    }

    void Update()
    {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, shrinkSpeed * 0.86f * Time.deltaTime);
        if (transform.localScale.x <= 0.2f)
        {
            Destroy(gameObject);
        }
    }
}
