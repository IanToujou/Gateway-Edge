using UnityEngine;

public class TitleUI : MonoBehaviour {
    
    void Update() {
        if(Input.anyKeyDown) {
            MenuUIManager.SetActiveCanvas(MenuUILayout.MENU);
        }
    }

}
