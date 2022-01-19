using UnityEngine;

public class ExitConfirmationUI : MonoBehaviour {

    private UISoundManager soundManager;

    void Awake() {
        soundManager = UISoundManager.GetInstance();
    }

    public void ButtonPressYes() {
        soundManager.PlayAudioClip(UISoundClipList.SFX_UI_CLICK);
        Application.Quit();
    }

    public void ButtonPressNo() {
        soundManager.PlayAudioClip(UISoundClipList.SFX_UI_CLICK);
        MenuUIManager.SetActiveCanvas(MenuUILayout.MENU);
    }

}
