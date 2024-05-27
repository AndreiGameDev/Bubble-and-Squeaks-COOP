using UnityEngine;
using UnityEngine.SceneManagement;

// Implemented by Andrei
public class TownTriggerNextZone : MonoBehaviour {
    [SerializeField]string loadLevel;
    private void Awake() {

        if(PlayerPrefs.HasKey("LastPlayedLevel")) {
            loadLevel = PlayerPrefs.GetString("LastPlayedLevel");
        } else {
            loadLevel = "Tutorial Level";
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        PlayerRefferenceMaster player = collision.gameObject.GetComponent<PlayerRefferenceMaster>();
        if(player != null) {

            SceneManager.LoadScene(loadLevel);
        }
    }
}
