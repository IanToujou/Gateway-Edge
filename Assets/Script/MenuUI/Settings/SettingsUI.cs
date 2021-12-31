using UnityEngine;

public class SettingsUI : MonoBehaviour {

    public void ButtonPressBack() {
        MenuUIManager.SetActiveCanvas(MenuUILayout.MENU);
    }

}
