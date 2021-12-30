using UnityEngine;

public class ExitConfirmationUI : MonoBehaviour {

    public void ButtonPressYes() {
        Application.Quit();
    }

    public void ButtonPressNo() {
        UIManager.SetActiveCanvas(UILayout.MENU);
    }

}