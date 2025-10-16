using System.Collections.Generic;
using UnityEngine;

public class VampirismDetector
{
    private float _radius;
    private List<Collider2D> _results = new ();
    
    public VampirismDetector(float radius)
    {
        _radius = radius;
    }
    
    public bool TryDetectTarget(Transform transform, out Transform targetTransform)
    {
        targetTransform = null;
        Physics2D.OverlapCircle(transform.position, _radius, ContactFilter2D.noFilter, _results);
        targetTransform = FindNearestTarget(transform, _results);
        
        return targetTransform != null;
    }
    
    private Transform FindNearestTarget(Transform transform, List<Collider2D> results)
    {
        float maxDistance = float.MaxValue;
        Transform target = null;
        
        foreach(var result in results)
        {
            if(result.TryGetComponent(out Health _) == false)
                continue;
            
            if(result.TryGetComponent(out PlayerRoot _))
                continue;
            
            float distanceSquare = Vector2.SqrMagnitude((transform.position - result.transform.position));
            
            if(distanceSquare < maxDistance)
            {
                maxDistance = distanceSquare;
                target = result.transform;
            }
        }
        
        return target;
    }
}