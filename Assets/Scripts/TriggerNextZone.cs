using UnityEngine;
using UnityEngine.SceneManagement;
//Implemented by Andrei
public class TriggerNextZone : MonoBehaviour {
    [SerializeField] string nextSceneName;
    private void OnCollisionEnter2D(Collision2D collision) {
        PlayerRefferenceMaster player = collision.gameObject.GetComponent<PlayerRefferenceMaster>();
        if(player != null) {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
