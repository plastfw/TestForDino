using UnityEngine;
using Random = UnityEngine.Random;

public class Cylander : MonoBehaviour
{
    [SerializeField] private PatternEnemy[] _patterns;

    private void Start()
    {
        ActivateEnemy();
    }
    
    private void ActivateEnemy()
    {
        var index = Random.Range(0, _patterns.Length);

        _patterns[index].gameObject.SetActive(true);
    }
}
