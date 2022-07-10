using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    private const int FirstScene = 0;
    
    public void RestartGame()
    {
        SceneManager.LoadScene(FirstScene);
    }
}