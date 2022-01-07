using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    
    [SerializeField] private PlayerController playerController;
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

            playerController.SetFreezed(true);
            dialoguePanel.SetActive(true);

            if(Input.GetKeyDown(KeyCode.Space)) {
                nextKeyPress = true;
            }

            if(!playing) {
                playing = true;
                StartCoroutine(PlayDialogue(currentDialogue));
            }

        } else {
            playerController.SetFreezed(false);
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
            textList.Add("Hey! Are you awake?");
            textList.Add("Hmm you do seem to be awake.");
            textList.Add("You may ask yourself who I am, right? Just kidding, you are not capable of having thoughts or a voice like I do.");
            textList.Add("I am the system. I am the host of this world. You are one of my many workers.");
            textList.Add("You need to complete tasks for this system. If you fail... I'll need to take administrative actions and eliminate you.");
            textList.Add("Your task here is to deliver a packet to the physical destination address 0x00034B8, got it?");
            textList.Add("Just follow the path and deliver it under the time limit.");

            foreach(string currentText in textList) {
                
                ShowText(contentText, currentText);

                yield return new WaitForSeconds(0.5f);

                while(!nextKeyPress) {
                    yield return null;
                }

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
