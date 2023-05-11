using UnityEngine;

public class MapCreator : MapsList
{
    [SerializeField] private Vector3[] _mapCoordinates;
    void Start()
    {
        for (int index = 0; index < _mapCoordinates.Length; index++)
        {
            int randomMap = Random.Range(0, _map.Length-1);
            Instantiate(_map[randomMap], _mapCoordinates[index], transform.rotation, this.transform);
        }
    }
}
