using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzle : MonoBehaviour
{
    public List<FlowerLever> levers = new List<FlowerLever>();
    public Transform FlowerHolder;
    [SerializeField] int correctLevers;
    [SerializeField] int correctLeversPulled;
    [SerializeField] int incorrectLeversPulled;
    private void Start() {
        for(int i = 0; i < FlowerHolder.childCount; i++) {
            FlowerLever flowerLever = FlowerHolder.GetChild(i).GetComponent<FlowerLever>();
            if(flowerLever != null) {
                levers.Add(flowerLever);
                flowerLever.doorPuzzle = this;
            }
        }
        foreach(FlowerLever lever in levers) {
            if(lever.isCorrectFlower) {
                correctLevers++;
            }
        }
    }
    public void DoorOpen() {
        for(int i = 0;i < levers.Count;i++) {
            FlowerLever lever = levers[i];
            if(lever.isFlowerBloomed && lever.isCorrectFlower) {
                correctLeversPulled++;
            } else if(lever.isFlowerBloomed && !lever.isCorrectFlower) {
                incorrectLeversPulled++;
            }
        }
        if(correctLeversPulled == correctLevers && incorrectLeversPulled == 0) {
            gameObject.SetActive(false);
        } else {
            correctLeversPulled = 0;
            incorrectLeversPulled = 0;
        }
    }
}
