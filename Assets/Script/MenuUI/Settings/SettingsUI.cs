using UnityEngine;

public class SettingsUI : MonoBehaviour {

    public void ButtonPressBack() {
        UIManager.SetActiveCanvas(UILayout.MENU);
    }

}
