using UnityEngine;

public class FollowingCamera : CharacterSelection
{
    [SerializeField] private GameObject mainCharacter;

    [SerializeField] private float _returnSpeed;
    [SerializeField] private float _height = 10f;           
    [SerializeField] private float _backDistance = 6f;
    [SerializeField] private float range = 0.01f;

    private Vector3 currentVector;

    private void Start()
    {                
        _returnSpeed =  _character[SelectionCharacter].Speed / 2.65f;
                           
        transform.position = new Vector3(mainCharacter.transform.position.x, mainCharacter.transform.position.y + _height, mainCharacter.transform.position.z - _backDistance);
        transform.rotation = Quaternion.LookRotation(mainCharacter.transform.position - transform.position);
    }

    private void FixedUpdate()
    {
        CameraMove();

    }

    private void CameraMove()
    {
        currentVector = new Vector3(mainCharacter.transform.position.x, mainCharacter.transform.position.y + _height, mainCharacter.transform.position.z - _backDistance);

        if (Vector3.Distance(currentVector, transform.position) > range)
            transform.position = Vector3.Lerp(transform.position, currentVector, _returnSpeed * Time.fixedDeltaTime);
    }
}
