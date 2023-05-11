using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3;
    [SerializeField]  private float _rotateSpeed = 0.35f;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveCharacter(Vector3 moveDirection)
    {

        Vector3 offset = moveDirection * _moveSpeed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + offset);
    }

    public void RotateCharacter(Vector3 moveDirection) 
    {
        if (Vector3.Angle(transform.forward, moveDirection) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}