using UnityEngine;
//Implemented by Andrei
public class ObstacleDestroyer : MonoBehaviour {
    [SerializeField] GameObject target;

    private void OnDestroy() {
        target.SetActive(false);
    }
}
