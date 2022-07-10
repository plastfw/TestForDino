using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class AnimationController : MonoBehaviour
{
    private const string Speed = "Speed";
    
    private Animator _animator;
    private MeshMover _mover;

    private void OnEnable()
    {
        _mover = GetComponent<MeshMover>();
        _animator = GetComponent<Animator>();

        _mover.IsMoved += ChangeAnimation;
    }

    private void OnDisable()
    {
        _mover.IsMoved -= ChangeAnimation;
    }

    private void ChangeAnimation(int value)
    {
        _animator.SetInteger(Speed,value);
    }
}
