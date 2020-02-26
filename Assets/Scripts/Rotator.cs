using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed = 1f;
    
    void Update()
    {
        Camera.main.transform.Rotate(Vector3.forward, Time.deltaTime * rotateSpeed);
        
    }
}
