using UnityEngine;
//Implemented by Andrei
public class PlayerLevelScenes : MonoBehaviour {
    // This script is used as an instance to keep track in which scnene the player is in.
    static PlayerLevelScenes instance;
    public static PlayerLevelScenes Instance {
        get { return instance; }
    }
    [SerializeField] int[] playerLevelSceneIndexes;

    private void Awake() {
        if(instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

    public int[] GetPlayerLevelScenes() {
        return playerLevelSceneIndexes;
    }
}
