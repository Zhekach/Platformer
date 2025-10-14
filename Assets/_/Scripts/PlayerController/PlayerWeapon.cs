using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private float _power = 10f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Health enemy))
        {
            enemy.Damage(_power);
        }
    }
}