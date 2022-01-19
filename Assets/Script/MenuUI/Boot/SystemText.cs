using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SystemText : MonoBehaviour {
    
    private Text text;
    private bool playingAnimation;
    private UISoundManager soundManager;

    void Awake() {
        text = gameObject.GetComponent<Text>();
        playingAnimation = false;
        soundManager = UISoundManager.GetInstance();
    }

    void Update() {
        if(!playingAnimation) {
            playingAnimation = true;
            StartCoroutine(PlayAnimation());
        }
    }

    private IEnumerator PlayAnimation() {
        soundManager.PlayAudioClip(UISoundClipList.SFX_UI_STARTUP, false);
        text.text = "Booting System.";
        yield return new WaitForSeconds(0.5f);
        text.text = "Booting System..";
        yield return new WaitForSeconds(0.5f);
        text.text = "Booting System...";
        yield return new WaitForSeconds(0.5f);
        text.text = "Booting System.";
        yield return new WaitForSeconds(0.5f);
        text.text = "Booting System..";
        yield return new WaitForSeconds(0.5f);
        text.text = "Booting System...";
        yield return new WaitForSeconds(0.2f);
        text.text = "System Boot Successful";
        yield return new WaitForSeconds(1.3f);
        soundManager.PlayAudioClip(UISoundClipList.SFX_UI_POPUP, false);
        MenuUIManager.SetActiveCanvas(MenuUILayout.TITLE);
    }

}
