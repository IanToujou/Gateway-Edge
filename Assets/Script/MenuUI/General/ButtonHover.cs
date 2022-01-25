using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    
    private Text text;

    void Start() {
        text = GetComponentInChildren<Text>();
        text.color = Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        text.color = new Color(1f, 0.5f, 0f, 1f);
    }
 
    public void OnPointerExit(PointerEventData eventData) {
        text.color = Color.white;
    }

}
