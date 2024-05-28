using UnityEngine;
using UnityEngine.SceneManagement;
//Implemented by jack
public class MenuScript : MonoBehaviour {
    public void ChangeScene(string destination) {
        SceneManager.LoadScene(destination);
        if(SwapInputMode.Instance != null) {
            SwapInputMode.Instance.gameObject.SetActive(true);
        }
    }

    public void ResetProgres() {
        PlayerPrefs.DeleteKey("LastPlayedLevel");
    }
    public void Quit() {
        Application.Quit();
    }
}