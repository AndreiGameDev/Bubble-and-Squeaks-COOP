using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{
    private void Awake() {
        DontDestroyOnLoad(this);
    }
}
