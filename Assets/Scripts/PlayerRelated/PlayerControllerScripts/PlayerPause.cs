using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
// Implemented by Andrei
public class PlayerPause : MonoBehaviour {
    PauseMenu pauseMenu;
    public bool hasPressedPause;
    public List<PlayerInputManager> playerInputList;
    private void Update() {
        PauseInput();
    }

    public void PauseInput() {
        if(hasPressedPause) {
            Pause();
        }
    }

    public void Pause() {
        if(pauseMenu == null) {
            pauseMenu = PauseMenu.Instance;
        }
        if(!pauseMenu.gameObject.activeSelf) {
            PauseMenu.Instance.gameObject.SetActive(true);
        }
    }
}
