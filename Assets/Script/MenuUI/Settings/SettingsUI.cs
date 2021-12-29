using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsUI : MonoBehaviour {

    public void ButtonPressBack() {
        UIManager.SetActiveCanvas(UILayout.MENU);
    }

}
