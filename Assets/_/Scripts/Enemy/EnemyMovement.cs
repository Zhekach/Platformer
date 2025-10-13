using UnityEngine;

[RequireComponent(typeof(PlayerDetector), typeof(PingPong))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private PingPong _pingPong;
    [SerializeField] private PlayerChaser _playerChaser;
    [SerializeField] private float _speed = 3f;
    
    private void Awake()
    {
        _playerDetector = GetComponent<PlayerDetector>();
        _pingPong = GetComponent<PingPong>();
        _playerChaser = GetComponent<PlayerChaser>();
    }

    private void Start()
    {
        _playerChaser.Initialize(_speed);
        _pingPong.Initialize(_speed);
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
        _playerChaser.ChasePlayer(player);
        _pingPong.StopMoving();
    }
    
    private void PatrolZone()
    {
        Debug.Log("Patrol zone");
        _pingPong.StartMoving();
        _playerChaser.StopChasePlayer();
    }
}