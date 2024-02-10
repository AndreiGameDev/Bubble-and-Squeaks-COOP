using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPuzzleLevelManager : MonoBehaviour
{
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
            if(lever.isCorrectFlower) {
                lever.spriteRenderer.sprite = lever.bloomedSprite;
            }
        }
    }
    void HideLevers() {
        foreach(FlowerLever lever in doorPuzzleScript.levers) {
            if(lever.isCorrectFlower) {
                lever.spriteRenderer.sprite = lever.unbloomedSprite;
            }
        }
    }
}
