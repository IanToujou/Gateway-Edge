using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
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

    //Sets the person text, not animated.
    public void SetPersonText(string content) {
        personText.text = content;
    }

    //Sets the content text, animated.
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
        yield return new WaitForSeconds(0.25f);
        
        while(!nextKeyPress) {
            yield return null;
        }

        StartCoroutine(FadeText(text, false));
        yield return new WaitForSeconds(0.25f);

    }

    private IEnumerator PlayDialogue(int dialogueId) {

        List<string> textList = new List<string>();
        SetPersonText("System");

        if(dialogueId == 10) {
            
            textList.Add("Hey! Are you awake?");
            textList.Add("Hmm you do seem to be awake.");
            textList.Add("You may ask yourself who I am, right? Just kidding, you are not capable of having thoughts or a voice like I do.");
            textList.Add("I am the <color=aqua>SYSTEM</color>. I am the host of this world. You are one of my many workers.");
            textList.Add("You need to complete tasks for this system. If you fail... I will need to take administrative actions and <color=red>eliminate you</color>.");
            textList.Add("Your task here is to deliver a packet to the physical destination address <color=aqua>0x00034B8</color>, got it?");
            textList.Add("Just follow the path and deliver it under the time limit. I disabled your controls for this straight section.");

        } else if(dialogueId == -1) {

            textList.Add("Wait a moment... Do you see that curve in front of you?");
            textList.Add("Try to gain angular momentum by moving your mouse cursor on the screen.");
            textList.Add("You should be able to make this curve without any problems.");

        } else if(dialogueId == -2) {

            textList.Add("That was... a fail. But that was not your fault.");
            textList.Add("I need to <color=aqua>update</color> your angular movement because it is not up-to-date.");
            textList.Add("Hang in there...");
            textList.Add("And, done! You are free to go and try again.");

        } else if(dialogueId == -3) {

            textList.Add("Do you see these green little <color=lime>fragments</color> down there?");
            textList.Add("You can collect them to buy some stuff, just to satisfy your needs.");
            textList.Add("Do not question where they come from.");

        } else if(dialogueId == -4) {

            textList.Add("There are some bigger curves, but also smaller ones.");
            textList.Add("Pay attention to the curves and do <color=red>not collide</color> with the walls.");

        } else if(dialogueId == -5) {

            textList.Add("By the way, you can also press <color=yellow>(W)</color> to boost and <color=yellow>(S)</color> to brake. This may come in handy later on.");
            textList.Add("Feel free to use your movement to the fullest- You will need it.");

        } else if(dialogueId == -6) {

            textList.Add("Hey, look! There are two ways here. You can choose which way you want to go.");
            textList.Add("I warn you, the way on top looks a harder, but there may be something up there...");

        } else if(dialogueId == -7) {

            textList.Add("This here, is a <color=orange>protocol</color>. You can only find one protocol per level.");
            textList.Add("Look at this beautiful lost file of system information... Let me analyze it.");
            textList.Add("This is totally useless to me, it only contains intel about the local environment.");
            textList.Add("You can have it and read it. You cannot become sentient anyway.");

        } else if(dialogueId == -8) {

            textList.Add("You are very close to the end! But pay attention, the passage is quite narrow.");
            textList.Add("You remember how to brake, do you? Brake with <color=yellow>(S)</color> to go inside the passage.");

        } else if(dialogueId == 11) {

            textList.Add("Well done! You successfully completed the tutorial. I hope you will not fail the next one.");
            textList.Add("Alright... We will go to the <color=aqua>system overview</color>.");
            textList.Add("CMD_GOTO_OVERVIEW");

        }

        foreach(string currentText in textList) {

                if(currentText.Equals("CMD_GOTO_OVERVIEW")) {
                    SceneManager.LoadScene("SceneLevelSelection");
                    StopCoroutine(PlayDialogue(11));
                }

                SetContentText(currentText);
                yield return new WaitForSeconds(0.25f);

                while(!nextKeyPress) {
                    yield return null;
                }

                nextKeyPress = false;
                yield return new WaitForSeconds(0.25f);

        }

        currentDialogue = 0;
        nextKeyPress = false;
        playing = false;

    }

    public bool IsDialogueActive() {
        return playing;
    }

}
