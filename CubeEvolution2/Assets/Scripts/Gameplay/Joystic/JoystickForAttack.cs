using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickForAttack : JoystickHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private CharacterAttack _characterAttack;

    private void Update()
    {
            if (_characterAttack)
            {
                if (inputVector.x >= range || inputVector.x <= -range || inputVector.y >= range || inputVector.y <= -range)
                {
                    _characterAttack.SetAttackDirection(new Vector3(inputVector.x, 0, inputVector.y));
                    _characterAttack.RotateShootPoint(new Vector3(inputVector.x, 0, inputVector.y));
                    _characterAttack.ShootLine.SetActive(true);
                }
                else
                {
                    _characterAttack.RotateShootPoint(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
                    _characterAttack.ShootLine.SetActive(false);
                }
            }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (inputVector.x >= range || inputVector.x <= -range || inputVector.y >= range || inputVector.y <= -range) _characterAttack.Shoot();

        joystickBackground.rectTransform.anchoredPosition = joystickBackgroundStartPosition;

        ClickEffect();

        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;

    }
}
