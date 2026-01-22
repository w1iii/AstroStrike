using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Demo_Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit"); // works in editor only
    }
}
