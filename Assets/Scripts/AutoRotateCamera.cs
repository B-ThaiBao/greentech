using UnityEngine;

public class AutoRotateCamera : MonoBehaviour
{
    public float rotationSpeed = 2f; // Tốc độ quay, có thể chỉnh trong Inspector

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}

