using System.Collections.Generic;
using UnityEngine;

public class VampirismDetector : MonoBehaviour
{
    private float _radius;
    private List<Collider2D> _results = new ();
    
    public void Initialize(float radius)
    {
        _radius = radius;
    }
    
    public bool TryDetectTarget(out Transform targetTransform)
    {
        targetTransform = null;
        Physics2D.OverlapCircle(transform.position, _radius, ContactFilter2D.noFilter, _results);
        targetTransform = FindNearestTarget(_results);
        
        return targetTransform != null;
    }
    
    private Transform FindNearestTarget(List<Collider2D> results)
    {
        float maxDistance = float.MaxValue;
        Transform target = null;
        
        foreach(var result in results)
        {
            if(result.TryGetComponent(out Health _) == false)
                continue;
            
            if(result.TryGetComponent(out PlayerRoot _))
                continue;
            
            float distance = Vector2.Distance(transform.position, result.transform.position);
            
            if(distance < maxDistance)
            {
                maxDistance = distance;
                target = result.transform;
            }
        }
        
        return target;
    }
}
