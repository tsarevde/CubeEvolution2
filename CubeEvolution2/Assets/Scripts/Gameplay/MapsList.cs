using UnityEngine;

public abstract class MapsList : MonoBehaviour
{
    public GameObject[] _map {get; private set;}

    public void Awake()
    {
        _map = Resources.LoadAll<GameObject>("Maps");
    }
}
