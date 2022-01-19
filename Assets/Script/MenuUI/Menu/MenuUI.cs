using UnityEngine;

public class MenuUI : MonoBehaviour {

    private UISoundManager soundManager;

    void Awake() {
        soundManager = UISoundManager.GetInstance();
    }

    public void ButtonPressStart() {
        soundManager.PlayAudioClip(UISoundClipList.SFX_UI_CLICK);
        MenuUIManager.SetActiveCanvas(MenuUILayout.SAVE_LOAD);
    }

    public void ButtonPressSettings() {
        soundManager.PlayAudioClip(UISoundClipList.SFX_UI_CLICK);
        MenuUIManager.SetActiveCanvas(MenuUILayout.SETTINGS);
    }

    public void ButtonPressExit() {
        soundManager.PlayAudioClip(UISoundClipList.SFX_UI_CLICK);
        MenuUIManager.SetActiveCanvas(MenuUILayout.EXIT_CONFIRMATION);
    }

}
