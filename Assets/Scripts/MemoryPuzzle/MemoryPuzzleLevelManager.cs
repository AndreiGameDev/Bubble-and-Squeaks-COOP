using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPuzzleLevelManager : MonoBehaviour {
    DoorPuzzle doorPuzzleScript;
    [SerializeField] float timeShowingCorrectLevers;
    private void Awake() {
        doorPuzzleScript = FindAnyObjectByType<DoorPuzzle>();
    }
    private void Start() {
        StartCoroutine(StartLevel());
    }
    IEnumerator StartLevel() {
        ShowCorrectLevers();
        yield return new WaitForSecondsRealtime(timeShowingCorrectLevers);
        HideLevers();
    }
    void ShowCorrectLevers() {
        foreach(FlowerLever lever in doorPuzzleScript.levers) {
            switch(lever._correctState) {
                case LeverStates.Illuminated:
                    lever.ChangeModelBloom();
                    break;
                case LeverStates.Withered:
                    lever.ChangeModelUnbloom();
                    break;
                default:
                    Debug.Log("You have a lever that the correct state is null");
                    break;
            }
        }
    }
    void HideLevers() {
        foreach(FlowerLever lever in doorPuzzleScript.levers) {
            lever.ChangeModelDefault();
        }
    }
}
