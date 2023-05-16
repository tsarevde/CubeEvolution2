using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickHandler : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    //Данные джойстика
    [SerializeField] protected Image joystickBackground;
    [SerializeField] protected Image joystick;
    [SerializeField] protected Image joystickArea;
    [SerializeField] protected float range;
    [SerializeField] private bool isEnable = false;

    //Начальная позиция джойстика
    protected Vector2 joystickBackgroundStartPosition;

    //Направление движения джойстика
    protected Vector2 inputVector;

    private bool joystickIsActive = false;

    private void Start()
    {
        RoundStarter.onRoundStart += EnableJoystick;
        RoundEnd.onRoundEnd += DisableJoystick;

        ClickEffect();
        VisableEffect();

        joystickBackgroundStartPosition = joystickBackground.rectTransform.anchoredPosition;
    }

    private void OnDisable()
    {
        RoundStarter.onRoundStart -= EnableJoystick;
        RoundEnd.onRoundEnd += DisableJoystick;
    }

    private void EnableJoystick()
    {
        isEnable = true;
        VisableEffect();
    }

    private void DisableJoystick()
    {
        isEnable = false;
        VisableEffect();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isEnable)
        {
            Vector2 joystickPosition;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground.rectTransform, eventData.position, eventData.pressEventCamera, out joystickPosition))
            {
                joystickPosition.x = (joystickPosition.x * 2 / joystickBackground.rectTransform.sizeDelta.x);
                joystickPosition.y = (joystickPosition.y * 2 / joystickBackground.rectTransform.sizeDelta.y);

                inputVector = new Vector2(joystickPosition.x, joystickPosition.y);

                if (inputVector.magnitude > 1f)
                {
                    inputVector = inputVector.normalized;
                }

                joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBackground.rectTransform.sizeDelta.x / 2), 
                                                                                        inputVector.y * (joystickBackground.rectTransform.sizeDelta.y / 2));
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isEnable)
        {
            ClickEffect();

            Vector2 joystickBackgroundPosition;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickArea.rectTransform, eventData.position, eventData.pressEventCamera, out joystickBackgroundPosition))
                joystickBackground.rectTransform.anchoredPosition = new Vector2(joystickBackgroundPosition.x, joystickBackgroundPosition.y);
        }
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        if (isEnable)
        {
            joystickBackground.rectTransform.anchoredPosition = joystickBackgroundStartPosition;

            ClickEffect();

            inputVector = Vector2.zero;
            joystick.rectTransform.anchoredPosition = Vector2.zero;
        }
    }

    //Изменение прозрачности джойстика
    public void ClickEffect()
    {
        if (!joystickIsActive)
        {
            joystick.color = new Color (255f, 255f, 255f, 0.6f);
            joystickIsActive = true;
        }
        else
        {
            joystick.color = new Color (255f, 255f, 255f, 1f);
            joystickIsActive = false;
        }
    }

    private void VisableEffect()
    {
        if (!isEnable)
        {
            joystick.color = new Color (255f, 255f, 255f, 0f);
            joystickBackground.color = new Color (255f, 255f, 255f, 0f);
        }
        else
        {
            joystick.color = new Color (255f, 255f, 255f, 0.6f);
            joystickBackground.color = new Color (255f, 255f, 255f, 0.6f);
        }
    }
}
