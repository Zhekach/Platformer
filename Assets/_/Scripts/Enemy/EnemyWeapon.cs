using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private float _power = 5f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHealth player))
            player.GetDamage(_power);
    }
}