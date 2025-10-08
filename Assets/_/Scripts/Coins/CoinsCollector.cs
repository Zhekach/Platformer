using UnityEngine;

[RequireComponent(typeof(PlayerController), typeof(Collider2D))]
public class CoinsCollector : MonoBehaviour
{
    [SerializeField] private int _count;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Coin>(out _))
        {
            _count++;
        }
    }
}
