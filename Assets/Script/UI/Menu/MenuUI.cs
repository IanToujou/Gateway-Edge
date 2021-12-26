using UnityEngine;

public class MenuUI : MonoBehaviour {

    public void ButtonPressStart() {
        UIManager.SetActiveCanvas(UILayout.SAVE_LOAD);
    }

    public void ButtonPressSettings() {
        UIManager.SetActiveCanvas(UILayout.SETTINGS);
    }

    public void ButtonPressExit() {
        UIManager.SetActiveCanvas(UILayout.EXIT_CONFIRMATION);
    }

}
