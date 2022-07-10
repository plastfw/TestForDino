using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Player))]
public class MeshMover : MonoBehaviour
{
    [SerializeField] private Transform[] _path;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private Restarter _restarter;

    private Player _player;
    private NavMeshAgent _agent;
    private int _index = 0;
    private int _minSpeed = 0;
    private int _maxSpeed = 3;

    public float Speed => _agent.speed;

    public event Action<int> IsMoved;

    private void OnEnable()
    {
        _player = GetComponent<Player>();
        _agent = GetComponent<NavMeshAgent>();

        _player.AllEnemiesIsDead += MoveNextPoint;
        _startScreen.IsTouched += MoveNextPoint;
        
        _agent.speed = _minSpeed;
        IsMoved?.Invoke(_minSpeed);
    }

    private void OnDisable()
    {
        _player.AllEnemiesIsDead -= MoveNextPoint;
        _startScreen.IsTouched -= MoveNextPoint;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out PathPoint point))
        {
            _agent.speed = _minSpeed;
            IsMoved?.Invoke(_minSpeed);
        }
    }
    
    private void MoveNextPoint()
    {
        if (RightToMove())
        {
            _agent.speed = _maxSpeed;
            IsMoved?.Invoke(_maxSpeed);
            
            _agent.destination = _path[_index].position;
            _index++;
        }
        else
        {
            _restarter.RestartGame();
        }
    }

    private bool RightToMove()
    {
        if (_index != _path.Length)
            return true;
        else
            return false;
    }
}