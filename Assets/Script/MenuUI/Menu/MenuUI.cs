using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuUI : MonoBehaviour {

    private UISoundManager soundManager;

    void Awake() {
        soundManager = UISoundManager.GetInstance();
    }

    void OnEnable() {
        foreach(Button all in GetComponentsInChildren<Button>()) {
            all.GetComponentInChildren<Text>().color = Color.white;
        }
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

    public void ButtonPressMusic() {
        soundManager.PlayAudioClip(UISoundClipList.SFX_UI_CLICK);
        MenuUIManager.SetActiveCanvas(MenuUILayout.MUSIC);
    }

    public void ButtonPressCredits() {
        soundManager.PlayAudioClip(UISoundClipList.SFX_UI_CLICK);
        MenuUIManager.SetActiveCanvas(MenuUILayout.CREDITS);
    }

}
