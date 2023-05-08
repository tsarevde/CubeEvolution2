using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [Header("Object for following")]
    [SerializeField] private GameObject mainCharacter;

    [Header("Camera propertys")]
    [SerializeField] private float returnSpeed;
    [SerializeField] private float height;           
    [SerializeField] private float rearDistance;

    private Vector3 currentVector;

    void Start()
    {                                    
        transform.position = new Vector3(mainCharacter.transform.position.x, mainCharacter.transform.position.y + height, mainCharacter.transform.position.z - rearDistance);
        transform.rotation = Quaternion.LookRotation(mainCharacter.transform.position - transform.position);
    }

    void Update()
    {
        CameraMove();
    }

    void CameraMove()
    {
        currentVector = new Vector3(mainCharacter.transform.position.x, mainCharacter.transform.position.y + height, mainCharacter.transform.position.z - rearDistance);
        transform.position = Vector3.Lerp(transform.position, currentVector, returnSpeed * Time.deltaTime);
    }
}
