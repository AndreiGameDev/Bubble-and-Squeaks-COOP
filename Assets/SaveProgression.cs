using UnityEngine;
using UnityEngine.SceneManagement;

// Implemented by andrei
public class SaveProgression : MonoBehaviour {
    private void Awake() {
        PlayerPrefs.SetString("LastPlayedLevel", SceneManager.GetActiveScene().name);
    }
}
