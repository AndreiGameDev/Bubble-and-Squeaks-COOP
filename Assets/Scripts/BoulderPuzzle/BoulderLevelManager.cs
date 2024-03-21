using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderLevelManager : MonoBehaviour
{
    [SerializeField]int pressurePointsHeld;
    [SerializeField] int pressurePoints;
    public static BoulderLevelManager Instance;
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
            Debug.Log("Open Door");
        }
    }
}
