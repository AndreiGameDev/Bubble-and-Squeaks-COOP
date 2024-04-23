using UnityEngine;
using UnityEngine.SceneManagement;
//Implemented by jack improved by Andrei
public class PauseMenu : MonoBehaviour
{

    private void OnEnable() {
        Time.timeScale = 0f;
    }
    public void Resume() {
        Time.timeScale = 1f;
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Reset() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}