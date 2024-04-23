using UnityEngine;
//Implemented by Andrei
public class PlayerLevelScenes : MonoBehaviour
{ 
    // This script is used as an instance to keep track in which scnene the player is in.
    public static PlayerLevelScenes instance;
    [SerializeField] int[] playerLevelSceneIndexes;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

    public int[] GetPlayerLevelScenes() {
        return playerLevelSceneIndexes;
    }
}
