using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
//Implemented by Andrei
public class DialogueManager : MonoBehaviour {
    // Singleton
    private static DialogueManager instance;
    public static DialogueManager Instance {
        get {
            return instance;
        }
    }

    // Queue for dialogue sentences and future speakers
    Queue<string> speakerSentences;

    [Header("UI elements")]
    [SerializeField]
    GameObject dialogueCanvasGO;
    [SerializeField]
    TextMeshProUGUI speakerUI;
    [SerializeField]
    TextMeshProUGUI speakerSentenceUI;

    public List<PlayerInput> playerInputList;
    private void Awake() {
        if(instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        speakerSentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {
        speakerSentences.Clear();

        speakerUI.text = dialogue.dialogueOwner;
        foreach(string sentence in dialogue.sentences) {
            speakerSentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        // Go in dialogue mode
        foreach(PlayerInput playerInput in playerInputList) {
            playerInput.SwitchCurrentActionMap("UI");
        }
        dialogueCanvasGO.SetActive(true);
    } // When player interacts, it loads the sentences and switches player input to UI Mode

    public void DisplayNextSentence() {
        if(speakerSentences.Count == 0) {
            EndDialogue();
            return;
        }
        string sentence =  speakerSentences.Dequeue();
        speakerSentenceUI.text = sentence;
    } // Updates ui to next sentence, ends dialogue if no more sentences to display
    
    void EndDialogue() {
        dialogueCanvasGO.SetActive(false);
        foreach(PlayerInput playerInput in playerInputList) {
            playerInput.SwitchCurrentActionMap("Player");
        }
    } // Hides UI and goes back to normal input mode
}
