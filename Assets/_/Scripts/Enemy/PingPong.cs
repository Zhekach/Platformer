using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PingPong : MonoBehaviour
{
    [SerializeField] private float _lengthX;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private Coroutine _moving;
    private float _startX;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startX = transform.position.x;
    }

    public void StartMoving()
    {
        _moving = StartCoroutine(Move());
    }
    
    public void StopMoving()
    {
        if (_moving == null) 
            return;
        
        StopCoroutine(_moving);
        _moving = null;
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