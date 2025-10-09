using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private float _power = 10f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.GetDamage(_power);
        }
    }
}