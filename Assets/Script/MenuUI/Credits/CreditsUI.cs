using UnityEngine;
using UnityEngine.UI;

public class CreditsUI : MonoBehaviour {

    void OnEnable() {
        foreach(Button all in GetComponentsInChildren<Button>()) {
            all.GetComponentInChildren<Text>().color = Color.white;
        }
    }

    public void ButtonPressBack() {
        UISoundManager.GetInstance().PlayAudioClip(UISoundClipList.SFX_UI_CLICK);
        MenuUIManager.SetActiveCanvas(MenuUILayout.MENU);
    }

}
