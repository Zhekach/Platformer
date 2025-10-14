using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerChaser : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _playerTransform;
    
    private float _speed;
    private Coroutine _moving;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Initialize(float speed)
    {
        _speed = speed;    
    }
    
    public void ChasePlayer(Transform target)
    {
        _playerTransform = target;
        _moving = StartCoroutine(Chasing());
    }

    public void StopChasePlayer()
    {
        if (_moving == null) 
            return;
        
        StopCoroutine(_moving);
        _moving = null;
    } 
    
    private IEnumerator Chasing()
    {
        while (enabled)
        {
            float direction = _playerTransform.position.x > transform.position.x ? 1 : -1;
            _rigidbody.linearVelocity = new Vector2(direction * _speed, _rigidbody.linearVelocity.y);
            
            yield return null;
        }
    }
}