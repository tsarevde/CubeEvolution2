using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private static DeathZone _zone;

    [SerializeField] private Transform _circleTransform;
    [SerializeField] private Transform _upTransform;
    [SerializeField] private Transform _downTransform;
    [SerializeField] private Transform _leftTransform;
    [SerializeField] private Transform _rightTransform;

    [SerializeField] private Vector3 _circleSize;
    [SerializeField] private Vector3 _circlePosition;

    [SerializeField] private float _circleSpeed;
    [SerializeField] private Vector3 _targetCircleSize;

    public static int Damage;

    private void Awake()
    {
        _zone = this;

        _circlePosition = transform.position;
        _circleSpeed = 1.35f;

        _circleTransform = transform.Find("Circle");
        _upTransform = transform.Find("Up");
        _downTransform = transform.Find("Down");
        _leftTransform = transform.Find("Left");
        _rightTransform = transform.Find("Right");

        Damage = 5;

        SetCircleSize(new Vector3(125, 125));
        _targetCircleSize = new Vector3(125, 125);

        StartCoroutine(WaveCircle());
    }

    private void Update()
    {
        Vector3 sizeChangeVector = (_targetCircleSize - _circleSize).normalized;
        Vector3 newCircleSize = _circleSize + sizeChangeVector * Time.deltaTime * _circleSpeed;

        SetCircleSize(newCircleSize);
    }

    private IEnumerator WaveCircle()
    {
        while (true)
        {
            if (_targetCircleSize != new Vector3(5, 5) ) _targetCircleSize -= new Vector3(10, 10);
            Damage += 5;

            yield return new WaitForSeconds(12f);
        }
    }

    private void SetCircleSize(Vector3 size)
    {
        _circleSize = size;
        _circleTransform.localScale = size;

        _upTransform.localScale = new Vector3(size.x*27, size.x*13, 1);
        _upTransform.localPosition = new Vector3(0, 1, _upTransform.localScale.y / 2  + size.y / 2);

        _downTransform.localScale = new Vector3(size.x*27, size.x*31, 1);
        _downTransform.localPosition = new Vector3(0, 1, -_downTransform.localScale.y / 2  - size.y / 2);

        _leftTransform.localScale = new Vector3(size.x*13, size.y, 1);
        _leftTransform.localPosition = new Vector3(_leftTransform.localScale.x / 2  + size.x / 2, 1, 0);

        _rightTransform.localScale = new Vector3(size.x*13, size.y, 1);
        _rightTransform.localPosition = new Vector3(-_rightTransform.localScale.x / 2  - size.x / 2, 1, 0);
    }

    private bool isOutsideCircle(Vector3 position)
    {
        return Vector3.Distance(position, _circlePosition) > _circleSize.x / 2;
    }

    public static bool isOutsideCircleStatic(Vector3 position)
    {
        return _zone.isOutsideCircle(position);
    }
}
