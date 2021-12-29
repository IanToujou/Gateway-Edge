using UnityEngine;

public class TitleUI : MonoBehaviour {
    
    void Update() {
        if(Input.anyKeyDown) {
            UIManager.SetActiveCanvas(UILayout.MENU);
        }
    }

}
