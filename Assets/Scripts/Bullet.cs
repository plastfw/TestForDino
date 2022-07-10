using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    
    private Tween _shoot;
    
    private void OnTriggerEnter(Collider collider)
    {
        _shoot.Kill();
        Deactivate();
    }

    public void Shoot(Vector3 position)
    {
        _shoot = transform.DOMove(position,_speed);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
