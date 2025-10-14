using System.Collections.Generic;
using UnityEngine;

public class ZonesSpawner : MonoBehaviour
{
    [SerializeField] private List<Zone> _zones;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _spawnsCount;
    
    
    private void Start()
    {
        for(var i = 0; i < _spawnsCount; i++)
        {
            var zone = _zones[Random.Range(0, _zones.Count)];
            var position = zone.GetRandomPosition();
            var rotation = zone.transform.rotation;
            
            var instance = Instantiate(_prefab, position, rotation);
            instance.transform.parent = zone.transform;
        }
    }
}