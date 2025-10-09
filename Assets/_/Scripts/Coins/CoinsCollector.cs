using System;
using UnityEngine;

[RequireComponent(typeof(PlayerRoot), typeof(Collider2D))]
public class CoinsCollector : MonoBehaviour
{
    [SerializeField] private int _count;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin) == false) 
            return;
        
        _count += coin.Value;
        Destroy(coin.gameObject);
    }
}