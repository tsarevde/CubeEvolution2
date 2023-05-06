using UnityEngine;

public class CubeRotateUI : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50000f;
    [SerializeField] private Rigidbody rb;
    private bool dragging = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragging = true;
        }
        if (Input.GetMouseButtonUp(0))
            dragging = false;
    }
    private void FixedUpdate() 
    {
        if (dragging)
        {
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
            rb.AddTorque(Vector3.down * x);
        }
    }
}
