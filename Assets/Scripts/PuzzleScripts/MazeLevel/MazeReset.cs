using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
//Implemented by Andrei
public class MazeReset : MonoBehaviour
{
    [SerializeField]List<int> MazeScenes;
    int nextMaze;
    private void Awake() {
        List<int> nextMazeOptions = new List<int>();
        foreach(int i in MazeScenes) {
            if(i != SceneManager.GetActiveScene().buildIndex) {
                nextMazeOptions.Add(i);
            }
        }
        int rngIndex = Random.Range(0, nextMazeOptions.Count);
        nextMaze = nextMazeOptions[rngIndex];
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        PlayerRefferenceMaster player;
        if(collision.transform.TryGetComponent(out player)) {
            Debug.Log(nextMaze);
            SceneManager.LoadScene(nextMaze);
        }
    }
}
