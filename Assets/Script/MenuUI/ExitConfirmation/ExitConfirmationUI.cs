using UnityEngine;
using UnityEngine.UI;

public class ExitConfirmationUI : MonoBehaviour {

    private UISoundManager soundManager;

    void Awake() {
        soundManager = UISoundManager.GetInstance();
    }

    void OnEnable() {
        foreach(Button all in GetComponentsInChildren<Button>()) {
            all.GetComponentInChildren<Text>().color = Color.white;
        }
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
