using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//Implemented by Andrei
public class DoorPuzzle : MonoBehaviour
{
    public List<FlowerLever> levers = new List<FlowerLever>();
    public Transform FlowerHolder;
    [SerializeField] int correctLeversPulled;
    public UnityEvent doorOpen;
    [SerializeField] AudioClip doorOpenSFX;
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
            doorOpen.Invoke();
        } else {
            correctLeversPulled = 0;
        }
    }
}
