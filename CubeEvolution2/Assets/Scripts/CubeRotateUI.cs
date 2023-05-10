using UnityEngine;

public class CubeRotateUI : MonoBehaviour
{
    [SerializeField] private int rotationSpeed = 20;
    [SerializeField] private Rigidbody rb;
    private bool dragging = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate() 
    {
        if (dragging)
        {
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
            rb.AddTorque(Vector3.down * x, ForceMode.VelocityChange);
        }
    }

    private void OnMouseDown()
    {
        dragging = true;
    }
    private void OnMouseUp()
    {
        dragging = false;
    }
}
