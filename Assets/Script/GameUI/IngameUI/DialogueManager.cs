using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Text personText;
    [SerializeField] private Text contentText;

    private bool nextKeyPress;
    private bool playing;
    private int currentDialogue;

    void Awake() {
        dialoguePanel.SetActive(false);
        nextKeyPress = false;
        playing = false;
        personText.text = "";
        contentText.text = "";
    }

    void Update() {

        if(currentDialogue != 0) {

            dialoguePanel.SetActive(true);
            Debug.Log(currentDialogue);

            if(Input.GetKeyDown(KeyCode.Space)) {
                nextKeyPress = true;
            }

            if(!playing) {
                playing = true;
                StartCoroutine(PlayDialogue(currentDialogue));
            }

        } else {
            dialoguePanel.SetActive(false);
        }
        
    }

    public void SetActiveDialogue(int dialogueId) {
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
        
        while(!nextKeyPress) {
            yield return null;
        }

        nextKeyPress = false;
        StartCoroutine(FadeText(text, false));
        yield return new WaitForSeconds(0.5f);

    }

    private IEnumerator PlayDialogue(int dialogueId) {
        
        Debug.Log("Playing dialogue");

        if(dialogueId == 10) {

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
