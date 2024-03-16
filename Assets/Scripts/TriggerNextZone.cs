using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerNextZone : MonoBehaviour {
    [SerializeField] string nextSceneName;
    private void OnCollisionEnter2D(Collision2D collision) {
        PlayerRefferenceMaster player = collision.gameObject.GetComponent<PlayerRefferenceMaster>();
        if(player != null) {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
