using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MeshMover : MonoBehaviour
{
    [SerializeField] private Transform[] _path;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private StartScreen _startScreen;
    
    private NavMeshAgent _agent;
    private int _index = 0;

    private void OnEnable()
    {
        _agent = GetComponent<NavMeshAgent>();
        _startScreen.IsTouched += MoveNextPoint;
    }

    private void OnDisable()
    {
        _startScreen.IsTouched -= MoveNextPoint;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveNextPoint();
        }
    }

    private void MoveNextPoint()
    {
        _agent.destination = _path[_index].position;
        _index++;
    }
}