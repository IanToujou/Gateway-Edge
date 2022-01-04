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

        StartCoroutine(FadeText(text, false));
        yield return new WaitForSeconds(0.5f);

    }

    private IEnumerator PlayDialogue(int dialogueId) {

        if(dialogueId == 10) {

            List<string> textList = new List<string>();
            textList.Add("1");
            textList.Add("2");
            textList.Add("3");
            textList.Add("4");
            textList.Add("5");
            textList.Add("6");

            foreach(string currentText in textList) {
                
                ShowText(contentText, currentText);

                yield return new WaitForSeconds(0.5f);

                while(!nextKeyPress) {
                    yield return null;
                }

                Debug.Log("Key pressed");

                nextKeyPress = false;
                yield return new WaitForSeconds(0.5f);

            }

        } else if(dialogueId == -2) {



        }

        currentDialogue = 0;
        playing = false;

    }

    public bool IsDialogueActive() {
        return playing;
    }

}
