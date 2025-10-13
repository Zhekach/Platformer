using System;
using System.Collections;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float _radius = 7f;
    [SerializeField] private LayerMask _playerLayer;

    [Header("Debug")]
    [SerializeField] private bool _drawGizmos;

    private readonly WaitForSeconds _detectionInterval = new WaitForSeconds(1);
    private bool _isPlayerDetected;

    public event Action<Transform> OnPlayerDetected;
    public event Action OnPlayerMissed;
    
    private void OnEnable()
    {
        StartCoroutine(PlayerDetecting());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public bool TryDetectPlayer(out Transform playerTransform)
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, _radius, _playerLayer);

        if (playerCollider != null)
        {
            playerTransform = playerCollider.transform;
            return true;
        }

        playerTransform = null;
        return false;
    }

    private IEnumerator PlayerDetecting()
    {
        while (enabled)
        {
            bool isPlayerDetectedNow = TryDetectPlayer(out Transform playerTransform);

            if(isPlayerDetectedNow == false && _isPlayerDetected)
            {
                _isPlayerDetected = false;
                OnPlayerMissed?.Invoke();
            }

            else if (isPlayerDetectedNow && _isPlayerDetected == false)
            {
                _isPlayerDetected = true;
                OnPlayerDetected?.Invoke(playerTransform);
            }
            
            yield return _detectionInterval;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_drawGizmos == false)
            return;

        Gizmos.color = _isPlayerDetected ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}