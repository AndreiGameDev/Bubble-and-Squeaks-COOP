using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemDefaultObject : MonoBehaviour
{
    private void OnEnable() {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
}
