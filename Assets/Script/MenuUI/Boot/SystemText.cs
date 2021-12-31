using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SystemText : MonoBehaviour {
    
    private Text text;
    private bool playingAnimation;

    void Awake() {
        text = gameObject.GetComponent<Text>();
        playingAnimation = false;
    }

    void Update() {
        if(!playingAnimation) {
            playingAnimation = true;
            StartCoroutine(PlayAnimation());
        }
    }

    private IEnumerator PlayAnimation() {
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
        MenuUIManager.SetActiveCanvas(MenuUILayout.TITLE);
    }

}
