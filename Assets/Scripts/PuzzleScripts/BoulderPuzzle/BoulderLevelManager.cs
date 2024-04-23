using UnityEngine;
using UnityEngine.Events;
//Implemented by Andrei
public class BoulderLevelManager : MonoBehaviour
{
    [SerializeField]int pressurePointsHeld;
    [SerializeField] int pressurePoints;
    public static BoulderLevelManager Instance;
    [SerializeField] UnityEvent openDoor;
    AudioManager audioManager;
    [SerializeField] AudioClip SFX_OpenDoor;
    private void Awake() {
        Instance = this;
        pressurePoints = GameObject.FindGameObjectsWithTag("PressurePoint").Length;
    }

    private void Start() {
        audioManager = AudioManager.Instance;
    }

    public void PressurePointUpdate(bool Increase) {
        if(Increase) {
            pressurePointsHeld++;
            CanOpenDoor();
        } else {
            pressurePointsHeld--;
            CanOpenDoor();
        }
    }

    public void CanOpenDoor() {
        if(pressurePointsHeld == pressurePoints) {
            audioManager.PlaySFX(SFX_OpenDoor);
            openDoor.Invoke();
        }
    }
}
