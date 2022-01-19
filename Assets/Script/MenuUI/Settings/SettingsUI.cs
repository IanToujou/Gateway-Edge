using UnityEngine;

public class SettingsUI : MonoBehaviour {

    private UISoundManager soundManager;

    void Awake() {
        soundManager = UISoundManager.GetInstance();
    }

    public void ButtonPressBack() {
        soundManager.PlayAudioClip(UISoundClipList.SFX_UI_CLICK);
        MenuUIManager.SetActiveCanvas(MenuUILayout.MENU);
    }

}
