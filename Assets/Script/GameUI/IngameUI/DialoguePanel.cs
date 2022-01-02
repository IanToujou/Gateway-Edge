using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour {
    
    private static int currentDialogue;

    [SerializeField] private Text personText;
    [SerializeField] private Text contentText;

    private bool nextKeyPress;
    private bool playing;

    void Awake() {
        nextKeyPress = false;
        personText.text = "";
        contentText.text = "";
    }

    void Update() {

        if(currentDialogue != 0) {

            if(Input.GetKeyDown(KeyCode.Space)) {
                nextKeyPress = true;
            }

            if(!playing) {
                playing = true;
                PlayDialogue(currentDialogue);
            }

        }
        
    }

    public static void SetActiveDialogue(int dialogueId) {
        currentDialogue = dialogueId;
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

    private IEnumerator PlayDialogue(int dialogueId) {

        if(dialogueId == -1) {

            List<string> textList = new List<string>();
            textList.Add("You need to go straight kek lol rofl lmao");
            textList.Add("Lol just go idiot");

            foreach(string currentText in textList) {

                ShowText(contentText, currentText);

                yield return new WaitForSeconds(0.5f);

                while(!nextKeyPress) {
                    yield return null;
                }

                yield return new WaitForSeconds(0.5f);

            }

        } else if(dialogueId == -2) {



        }

        currentDialogue = 0;
        playing = false;

    }

}
