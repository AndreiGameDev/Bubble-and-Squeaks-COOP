using UnityEngine;
using UnityEngine.SceneManagement;
//Implemented by jack
public class MenuScript : MonoBehaviour {
    public void ChangeScene(string destination) {
        SceneManager.LoadScene(destination);
    }

    public void ResetProgres() {
        PlayerPrefs.DeleteKey("LastPlayedLevel");
    }
    public void Quit() {
        Application.Quit();
    }
}