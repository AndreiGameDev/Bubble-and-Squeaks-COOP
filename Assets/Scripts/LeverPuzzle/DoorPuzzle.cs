using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzle : MonoBehaviour
{
    public List<FlowerLever> levers = new List<FlowerLever>();
    public Transform FlowerHolder;
    [SerializeField] int correctLeversPulled;
    private void Start() {
        for(int i = 0; i < FlowerHolder.childCount; i++) {
            FlowerLever flowerLever = FlowerHolder.GetChild(i).GetComponent<FlowerLever>();
            if(flowerLever != null) {
                levers.Add(flowerLever);
                flowerLever.doorPuzzle = this;
            }
        }
    }
    public void DoorOpen() {
        for(int i = 0; i < levers.Count; i++) {
            FlowerLever lever = levers[i];
            if(lever._correctState == lever._currentState) {
                correctLeversPulled++;
            }
        }
        if(correctLeversPulled == levers.Count) {
            gameObject.SetActive(false);
        } else {
            correctLeversPulled = 0;
        }
    }
}
