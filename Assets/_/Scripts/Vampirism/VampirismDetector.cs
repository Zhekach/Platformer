using System.Collections.Generic;
using UnityEngine;

public class VampirismDetector : MonoBehaviour
{
    private float _radius;
    
    public void Initialize(float radius)
    {
        _radius = radius;
    }
    
    public bool TryDetectTarget(out Transform targetTransform)
    {
        List<Collider2D> results = new List<Collider2D>();
        float maxDistance = float.MaxValue;
        targetTransform = null;
        
        Physics2D.OverlapCircle(transform.position, _radius, ContactFilter2D.noFilter, results);
        
        foreach(var result in results)
        {
            if(result.TryGetComponent(out Health health) == false)
                continue;
            
            if(result.TryGetComponent(out PlayerRoot _))
                continue;
            
            float distance = Vector2.Distance(transform.position, result.transform.position);
            if(distance < maxDistance)
            {
                maxDistance = distance;
                targetTransform = result.transform;
            }
        }
        
        return targetTransform != null;
    }
}
