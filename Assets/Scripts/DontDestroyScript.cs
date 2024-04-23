using UnityEngine;
//Implemented by Andrei
public class DontDestroyScript : MonoBehaviour
{
    private void Awake() {
        DontDestroyOnLoad(this);
    }
}
