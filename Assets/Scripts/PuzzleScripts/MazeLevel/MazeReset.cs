using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
//Implemented by Andrei
public class MazeReset : MonoBehaviour
{
    [SerializeField]List<SceneAsset> MazeScenes;    
    private void OnCollisionEnter2D(Collision2D collision) {
        PlayerRefferenceMaster player = null;
        if(collision.transform.TryGetComponent<PlayerRefferenceMaster>(out player)) {
            int scene = Random.Range(0, MazeScenes.Count);
            SceneManager.LoadScene(MazeScenes[scene].name);
        }
    }
}
