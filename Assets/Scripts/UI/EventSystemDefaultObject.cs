using UnityEngine;
using UnityEngine.EventSystems;
//Implemented by Andrei
public class EventSystemDefaultObject : MonoBehaviour
{
    private void OnEnable() {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
}
