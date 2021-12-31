using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour {
    
    private static int currentDialogue;

    [SerializeField] private Text personText;
    [SerializeField] private Text contentText;

    private bool nextKeyPress;

    void Awake() {
        nextKeyPress = false;
        personText.text = "";
        contentText.text = "";
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            nextKeyPress = true;
        }
    }

    public void SetPersonText(string content) {
        ShowText(personText, content);
    }

    public void SetContentText(string content) {
        ShowText(contentText, content);
    }

    private IEnumerator FadeText(Text text, bool fadeIn) {
        
        if(fadeIn) {
            for (float i = 0; i <= 1; i += Time.deltaTime * 2) {
                text.color = new Color(text.color.r, text.color.g, text.color.b, i);
                yield return null;
            }
        } else {
            for (float i = 1; i >= 0; i -= Time.deltaTime * 2) {
                text.color = new Color(text.color.r, text.color.g, text.color.b, i);
                yield return null;
            }
        }

    }

    private void ShowText(Text text, string textString) {
        StartCoroutine(ShowTextAnimated(text, textString));
    }

    private IEnumerator ShowTextAnimated(Text text, string textString) {

        text.text = textString;
        StartCoroutine(FadeText(text, true));
        yield return new WaitForSeconds(0.5f);
        
        while(nextKeyPress) {
            yield return null;
        }

        nextKeyPress = false;
        StartCoroutine(FadeText(text, false));
        yield return new WaitForSeconds(0.5f);

    }

}
