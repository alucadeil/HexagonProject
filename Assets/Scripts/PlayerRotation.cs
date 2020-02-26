using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    public float rotationSpeed = 5f;
    public Vector2 mousePosition = new Vector2(0f, 1f);
    public bool flag = false;

    void Update()
    {
      if (!GameMenu.gameIsPaused)
      {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            flag = true;
        }
        if (flag)
        {
          float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
          Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
          transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            
        }

      }
  }
}
