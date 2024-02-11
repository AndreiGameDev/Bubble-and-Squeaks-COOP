using UnityEngine;

[System.Serializable]
public class Dialogue {
    public string dialogueOwner;

    [TextArea(3, 10)]
    public string[] sentences;
}
