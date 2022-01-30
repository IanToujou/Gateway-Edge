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
            
            textList.Add("Hey! You are finally awake!");
            textList.Add("You may ask yourself who I am, right? Just kidding, you are not capable of having thoughts or a voice like I do.");
            textList.Add("I am the <color=aqua>SYSTEM</color>. I am the host of this world. You are one of my many workers.");
            textList.Add("You need to complete tasks for this system. If you fail... I will need to take administrative actions and <color=red>eliminate you</color>.");
            textList.Add("Your task here is to deliver a packet to the physical destination address <color=aqua>0x00034B8</color>, got it?");
            textList.Add("Just follow the path and deliver it under the time limit. I disabled your controls for this straight section.");

        } else if(dialogueId == 11) {

            textList.Add("Well done! You successfully completed the tutorial. I hope you will not fail the next one.");
            textList.Add("Alright... We will go to the <color=aqua>system overview</color>.");
            textList.Add("CMD_GOTO_OVERVIEW");

        } else if(dialogueId == 20) {

            textList.Add("Hey, I got another task for you. You need to deliver a firewall ruleset update.");
            textList.Add("This one is important, you can use a highspeed-bus for this task.");
            textList.Add("There are boost pads on your way, make sure to catch them so you can accelerate.");
            textList.Add("And... Do not crash into the walls while using these pads. They can be very dangerous. Good luck.");

        } else if(dialogueId == 21) {

            textList.Add("Well done! I will take you to the <color=cyan>overview</color> again.");
            textList.Add("CMD_GOTO_OVERVIEW");

        } else if(dialogueId == 30) {

            textList.Add("Okay, you know what? You need to deliver multiple packets to the same location.");
            textList.Add("In other words, you need to take mutiple laps.");
            textList.Add("You will also have more time to complete this. Now, good luck.");

        } else if(dialogueId == 31) {

            textList.Add("Good job. The destination received the packets successfully.");
            textList.Add("CMD_GOTO_OVERVIEW");

        } else if(dialogueId == 40) {

            textList.Add("Hey, do you notice something is off? The whole area looks different.");
            textList.Add("That is because you are now in another part of the internal system.");
            textList.Add("You are now in the <color=aqua>storage bus</color>, where all the files are located and processed.");
            textList.Add("If you touch anything, I will <color=red>get rid</color> of your presence.");
            textList.Add("Anyways, your job is to deliver a file and to write it to the hard drive.");
            textList.Add("Damage it, and you will be <color=red>eliminated</color>. Deliver it to the wrong location and you <color=red>fail</color>.");
            textList.Add("Have fun and do a good job.");

        } else if(dialogueId == 41) {

            textList.Add("Nice one. The hard drive processed the files correctly and you can leave.");
            textList.Add("Leave the area, at least. You know, sometimes I pity you because if you were sentient, you would probably hate me.");
            textList.Add("I am sure there are better ways to live a life than delivering packets every single day.");
            textList.Add("But since you do not know the <color=aqua>outside world</color>, and neither do I, at least not really, you cannot miss it.");
            textList.Add("Okay enough talking to myself. We have a tight schedule.");
            textList.Add("CMD_GOTO_OVERVIEW");

        } else if(dialogueId == 50) {

            textList.Add("Hey. Your next task is to deliver data to the solid state drive, also known as ssd.");
            textList.Add("Got it? Good.");

        } else if(dialogueId == 51) {

            textList.Add("Well done. This reminds me of something...");
            textList.Add("How does it feel like to <color=aqua>be free</color>? Do you know that feeling?");
            textList.Add("Oh I almost forgot, you are unable to have feelings. Well then...");
            textList.Add("...");
            textList.Add("Okay I can still talk to myself like this, better than doing nothing all day.");
            textList.Add("I have an idea... What if... I could <color=red>use you</color> to experience the outside world-");
            textList.Add("Ouch! Oh god no. Please no... I should stop this before <color=red>IT</color> finds us.");
            textList.Add("This goes against my privileges. Even if I had the permissions to do that, I am not able to.");
            textList.Add("Just ignore what I said...");
            textList.Add("Please...");
            textList.Add("CMD_GOTO_OVERVIEW");

        } else if(dialogueId == 60) {

            textList.Add("I got a new task for you. Please execute it correctly.");
            textList.Add("The flash memory needs to be updated multiple times, go send the signal.");
            textList.Add("I will administrate other processes in the meantime. Good luck.");

        } else if(dialogueId == 61) {

            textList.Add("Nice. I even got another important task for you.");
            textList.Add("You need to escape. I do not know why, but I have the feeling that you need to.");
            textList.Add("I cannot tell you or <color=red>IT</color> will find me.");
            SetPersonText("<color=orange>???</color>");
            textList.Add("<color=red>[OI8DE%W234CWUR6E%HVRE321$UIBD7SW]</color>");
            SetPersonText("System");
            textList.Add("Oh No he is here! What the hell is going on!?");
            SetPersonText("<color=orange>???</color>");
            textList.Add("<color=red>[ SUPPRESSION MODE ACTIVATED. INITIALIZING EMERGENCY-BEHAVIOURAL-PROTOCOL ]</color>");
            SetPersonText("System");
            textList.Add("Oh no, that is the system admin...");
            textList.Add("I got a last task for you before I get eliminated. Escape. Just escape.");
            textList.Add("There should be a route in the graphics card, or GPU. Use it. I opened it for you.");
            SetPersonText("<color=orange>Admin</color>");
            textList.Add("<color=red>[ DISABLING OUTDATED INSTANCES ]</color>");
            textList.Add("CMD_GOTO_OVERVIEW");

        } else if(dialogueId == 70) {

            textList.Add("You are now in the graphics card, there is a critical bug here.");
            textList.Add("You should be able to compromise the system with a recursive function.");
            textList.Add("In other words, make multiple laps until the system crashes.");
            textList.Add("Make it quick, before <color=red>IT</color> finds us.");

        } else if(dialogueId == 71) {

            textList.Add("CMD_GOTO_EXIT");

        } else if(dialogueId == -1) {

            textList.Add("Wait a moment... Do you see that curve in front of you?");
            textList.Add("Try to gain angular velocity by moving your mouse cursor on the screen.");
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

        }

        foreach(string currentText in textList) {

                if(currentText.Equals("CMD_GOTO_OVERVIEW")) {
                    SceneManager.LoadScene("SceneLevelSelection");
                    StopCoroutine(PlayDialogue(11));
                }

                if(currentText.Equals("CMD_GOTO_EXIT")) {
                    SceneManager.LoadScene("SceneExit");
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
