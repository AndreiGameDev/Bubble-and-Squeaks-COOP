using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//Implemented by Andrei
public class UIDropdownSelect : MonoBehaviour, ISelectHandler {
    ScrollRect scrollRect;
    float scrollPosition = 1;
    void Start() {
        scrollRect = GetComponentInParent<ScrollRect>(true);

        int childCount = scrollRect.content.transform.childCount - 1;
        int childIndex = transform.GetSiblingIndex();
        // If the child index is in the first half, decrement it by one
        if(childIndex < childCount / 2) {
            childIndex = childIndex - 1;
        }

        // Calculate the position to scroll to based on the child index
        scrollPosition = 1 - (childIndex / (float)childCount);
    }

    public void OnSelect(BaseEventData eventData) {
        if(scrollRect != null) {
            scrollRect.verticalScrollbar.value = scrollPosition;
        }
    }
}
