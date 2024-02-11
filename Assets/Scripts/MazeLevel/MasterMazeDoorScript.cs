using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterMazeDoorScript : MonoBehaviour
{
    [SerializeField] MazeDoor lightDoor;
    [SerializeField] MazeDoor darkDoor;

    public bool isLightDoorOpen() {
        return lightDoor.isDoorOpen;
    }
    public bool isDarkDoorOpen() { 
        return darkDoor.isDoorOpen;
    }
}
