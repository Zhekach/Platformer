using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _places;
    [SerializeField] private Coin _coinPrefab;
    
    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        foreach (var place in _places)
        {
            Coin newCoin = Instantiate(_coinPrefab, place.position, place.rotation);
            newCoin.transform.parent = transform;
            place.gameObject.SetActive(false);
        }
    }
}