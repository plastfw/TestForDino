using System.Linq;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private MeshMover _mover;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet[] _bulletsPool;

    private Ray _ray;
    private RaycastHit _hit;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        ShootLogic();
    }

    private void ShootLogic()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (_mover.Speed != 0) return;

        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider.TryGetComponent(out Enemy _enemy))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (TryGetBullet(out Bullet _bullet))
                    {
                        _bullet.transform.position = _shootPoint.position;
                        _bullet.gameObject.SetActive(true);
                        _bullet.Shoot(_hit.point);
                    }
                }
            }
        }
    }

    private bool TryGetBullet(out Bullet result)
    {
        result = _bulletsPool.FirstOrDefault(p => p.gameObject.activeSelf == false);
        return result != null;
    }
}