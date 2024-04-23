using System.Collections;
using UnityEngine;
//Implemented by Andrei
public class DialogueCanvasAnimation : MonoBehaviour {
    [SerializeField]Transform backgroundBlurr;
    [SerializeField]Transform dialogueBox;
    [SerializeField] 
    private void OnEnable() {
        StartCoroutine(AnimationAppear());
    }

    IEnumerator AnimationAppear() {
        dialogueBox.localScale = Vector3.zero;
        StartCoroutine(BackgroundBlurrAppear());
        StartCoroutine(DialogueBoxAppear());
        yield return null;
    }

    IEnumerator BackgroundBlurrAppear() {
        Vector3 endPos = new Vector3(0, -1080, 0);
        float time = 0;
        float duration = .25f;
        while(time < 1) {
            float perc = Easing.Cubic.In(time);
            backgroundBlurr.localPosition = Vector3.Lerp(endPos, Vector3.zero, perc);
            time += Time.deltaTime / duration;
            yield return null;
        }
        backgroundBlurr.localPosition = Vector3.zero;
    }

    IEnumerator DialogueBoxAppear() {
        float time = 0;
        float duration = .5f;
        while(time < 1) {
            float perc = Easing.Back.InOut(time);
            dialogueBox.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, perc);
            time += Time.deltaTime / duration;
            yield return null;
        }
    }
}
