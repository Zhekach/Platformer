using System;
using UnityEngine;

[RequireComponent(typeof(PlayerDetector), typeof(PingPong))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private PingPong _pingPong;
    
    private void Awake()
    {
        _playerDetector = GetComponent<PlayerDetector>();
        _pingPong = GetComponent<PingPong>();
    }

    private void Start()
    {
        PatrolZone();
    }

    private void OnEnable()
    {
        _playerDetector.OnPlayerDetected += MoveToPlayer;
        _playerDetector.OnPlayerMissed += PatrolZone;
    }
    
    private void OnDisable()
    {
        _playerDetector.OnPlayerDetected -= MoveToPlayer;
        _playerDetector.OnPlayerMissed -= PatrolZone;
    }
    
    private void MoveToPlayer(Transform player)
    {
        Debug.Log("Move to player");
    }
    
    private void PatrolZone()
    {
        _pingPong.StartMoving();
        Debug.Log("Patrol zone");
    }
}