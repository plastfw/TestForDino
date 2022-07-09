using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Enemy))]
public class RagdollController : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodies;

    private Animator _animator;
    private Enemy _enemy;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
        DeactivatePhysical();
        _enemy.IsDead += MakePhysical;
    }

    private void OnDisable()
    {
        _enemy.IsDead -= MakePhysical;
    }


    private void DeactivatePhysical()
    {
        foreach (var rigidbodie in _rigidbodies)
        {
            rigidbodie.isKinematic = true;
        }
    }

    private void MakePhysical()
    {
        _animator.enabled = false;

        foreach (var rigidbodie in _rigidbodies)
        {
            rigidbodie.isKinematic = false;
        }
    }
}
