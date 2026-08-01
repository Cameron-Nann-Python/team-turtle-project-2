using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void StartRide()
    {
        SceneManager.LoadScene("River Scene");
    }

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene("Welcome Scene");
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}