using UnityEngine;
using UnityEngine.EventSystems;

public class CubeRotateUI : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    //[SerializeField] private float rotationSpeed = 10f;
    // [SerializeField] private Rigidbody rb;
    // private bool dragging = false;

    // private void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         dragging = true;
    //     }
    //     if (Input.GetMouseButtonUp(0))
    //         dragging = false;
    // }
    // private void FixedUpdate() 
    // {
    //     if (dragging)
    //     {
    //         float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
    //         rb.AddTorque(Vector3.down * x, ForceMode.VelocityChange);
    //     }
    // }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
