using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour {
    [SerializeField] GameObject target;

    private void OnDestroy() {
        target.SetActive(false);
    }
}
