using UnityEngine;
using UnityEngine.Events;
//Implemented by Andrei
public class BoulderLevelManager : MonoBehaviour
{
    [SerializeField]int pressurePointsHeld;
    [SerializeField] int pressurePoints;
    public static BoulderLevelManager Instance;
    [SerializeField] UnityEvent openDoor;
    private void Awake() {
        Instance = this;
        pressurePoints = GameObject.FindGameObjectsWithTag("PressurePoint").Length;
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
            openDoor.Invoke();
        }
    }
}
