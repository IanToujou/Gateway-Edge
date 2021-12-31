using UnityEngine;

public class MenuUI : MonoBehaviour {

    public void ButtonPressStart() {
        MenuUIManager.SetActiveCanvas(MenuUILayout.SAVE_LOAD);
    }

    public void ButtonPressSettings() {
        MenuUIManager.SetActiveCanvas(MenuUILayout.SETTINGS);
    }

    public void ButtonPressExit() {
        MenuUIManager.SetActiveCanvas(MenuUILayout.EXIT_CONFIRMATION);
    }

}
