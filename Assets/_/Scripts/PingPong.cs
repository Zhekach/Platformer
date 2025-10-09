using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
<<<<<<<< HEAD:Assets/_/Scripts/Enemy/EnemyPingPong.cs
public class EnemyPingPong : Enemy
========
public class PingPong : MonoBehaviour
>>>>>>>> main:Assets/_/Scripts/PingPong.cs
{
    [SerializeField] private float _lengthX;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private float _startX;  
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startX = transform.position.x;
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (enabled)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = _startX - Mathf.PingPong( _speed * Time.time, _lengthX);
            _rigidbody.MovePosition(newPosition);
            
            yield return null;
        }
    }
}
