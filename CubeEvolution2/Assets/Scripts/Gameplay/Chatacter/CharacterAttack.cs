using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private GameObject _point;
    private Vector3 _attackDirection;

    [SerializeField] public GameObject ShootLine;
    [SerializeField] private float _attackDistance = 10f;

    public void SetAttackDirection(Vector3 direction)
    {
        Ray ray = new Ray(_shootPoint.transform.position + new Vector3(0, -.498f, 0), _shootPoint.transform.forward);

        RaycastHit _hit;
        if (Physics.Raycast(ray, out _hit, _attackDistance))
        {
            ShowLine(_hit.distance);
        }
        else
        {
            ShowLine(_attackDistance);
        }

    }

    private void ShowLine(float distance)
    {
            ShootLine.transform.localScale = new Vector3(1, distance, 1);
            ShootLine.transform.localPosition = new Vector3(0, -1.19f, distance/2);
    }

    public void RotateShootPoint(Vector3 rotateDirection) 
    {
        if (Vector3.Angle(_shootPoint.transform.forward, rotateDirection) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(_shootPoint.transform.forward, rotateDirection, 5, 0);
            _shootPoint.transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(_bullet, _point.transform.position, _point.transform.rotation);
    }
}
