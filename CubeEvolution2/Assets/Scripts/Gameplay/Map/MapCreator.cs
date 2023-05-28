using UnityEngine;
using System.Collections;

public class MapCreator : MapsList
{
    [SerializeField] public Vector3[] _mapCoordinates;
    void Start()
    {
        StartCoroutine(RegenerationMap());
    }

    void CreateMap()
    {
        for (int index = 0; index < _mapCoordinates.Length; index++)
        {
            int randomMap = Random.Range(0, _map.Length-1);
            Instantiate(_map[randomMap], _mapCoordinates[index], transform.rotation, this.transform);
        }
    }

    void RemoveMap()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    private IEnumerator RegenerationMap()
    {

        while (true)
        {
            CreateMap();
            yield return new WaitForSeconds(300f);
            RemoveMap();
        }
    }
}
