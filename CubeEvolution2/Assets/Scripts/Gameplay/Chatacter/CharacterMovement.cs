using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : CharacterSelection
{
    [SerializeField] public StatusBarCharacter StatusBar;
    [SerializeField]  private float _rotateSpeed = 0.35f;
    private Rigidbody _rigidbody;
    private bool isStop = false;

    private void Start()
    {
        isStop = false;
        _rigidbody = GetComponent<Rigidbody>();
        RoundEnd.onRoundEnd += StopCharacter;
    }

    private void OnDisable()
    {
        RoundEnd.onRoundEnd += StopCharacter;
    }

    public void MoveCharacter(Vector3 moveDirection)
    {
        if (isStop) return;

        Vector3 offset = moveDirection * _character[SelectionCharacter].Speed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + offset);

        StatusBar.SetPosition(transform.position);
    }

    public void RotateCharacter(Vector3 moveDirection) 
    {
        if (Vector3.Angle(transform.forward, moveDirection) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    private void StopCharacter()
    {
        isStop = true;
    }
}