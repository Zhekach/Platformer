using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Zone : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider2D;
    
    private Vector2 _position;
    

    private void Awake()
    {
        _collider2D = GetComponent<BoxCollider2D>();
        _position = transform.position;
    }

    public Vector2 GetRandomPosition()
    {
        Vector2 size = _collider2D.size;
        Vector2 randomPoint = new Vector2(Random.Range(-size.x/2, size.x/2), Random.Range(-size.y/2, size.y/2));
        Vector2 randomPosition = _position + randomPoint;
        
        return randomPosition;
    }
    
    private void OnValidate()
    {
        _position = transform.position;
    }
}
