using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartScreen : MonoBehaviour
{
    [SerializeField] private Canvas _startScreen;
    
    private Button _button;

    public event Action IsTouched;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        _startScreen.enabled = false;
        IsTouched?.Invoke();
    }
}
