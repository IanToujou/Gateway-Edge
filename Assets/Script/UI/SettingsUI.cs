using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsUI : MonoBehaviour {

    void ButtonPressBack() {
        UIManager.SetActiveCanvas(UILayout.MENU);
    }

}
