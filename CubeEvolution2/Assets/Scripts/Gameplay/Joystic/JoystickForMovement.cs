using UnityEngine;

public class JoystickForMovement : JoystickHandler
{
    [SerializeField] private CharacterMovement _characterMovement;

    private void FixedUpdate()
    {
        if (_characterMovement)
        {
            if (inputVector.x != 0 || inputVector.y != 0)
            {
                _characterMovement.MoveCharacter(new Vector3(inputVector.x, 0, inputVector.y));
                _characterMovement.RotateCharacter(new Vector3(inputVector.x, 0, inputVector.y));
            }
            else
            {
                _characterMovement.MoveCharacter(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
                _characterMovement.RotateCharacter(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
            } 
        }
    }

}
