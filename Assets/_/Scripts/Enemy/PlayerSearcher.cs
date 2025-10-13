using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSearcher : MonoBehaviour
{
    [SerializeField] private float _searchRadius = 7f;
    [SerializeField] private LayerMask _playerLayer;

    [Header("Debug")] [SerializeField] private bool _drawGizmos;

    private WaitForSeconds _searchInterval = new WaitForSeconds(1);
    private bool _isPlayerInRadius;

    public event Action<Transform> OnPlayerDetected;


    private void OnEnable()
    {
        StartCoroutine(PlayerSearching());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public bool TryFindPlayer(out Transform playerTransform)
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, _searchRadius, _playerLayer);

        if (playerCollider != null)
        {
            playerTransform = playerCollider.transform;
            return true;
        }

        playerTransform = null;
        return false;
    }

    private IEnumerator PlayerSearching()
    {
        while (enabled)
        {
            _isPlayerInRadius = TryFindPlayer(out Transform playerTransform);

            if (_isPlayerInRadius)
                OnPlayerDetected?.Invoke(playerTransform);
            
            yield return _searchInterval;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_drawGizmos == false)
            return;

        Gizmos.color = _isPlayerInRadius ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, _searchRadius);
    }
}