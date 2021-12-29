using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EntrySystem : MonoBehaviour {
    
    [SerializeField] private Text monologueText;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Text skipText;
    [SerializeField] private GameObject backgroundPanel;

    private bool playing;
    private bool skipPressOnce;
    private int currentState;

    void Awake() {
        playing = false;
        skipPressOnce = false;
        currentState = EntryCutscene.ENTRY;
    }

    void Start() {
        skipText.gameObject.SetActive(false);

    }

    void Update() {

        if(currentState == EntryCutscene.ENTRY) {

            if(!playing) {

                playing = true;
                StartCoroutine(PlayEntryAnimation());

            } else {

                if(Input.GetKeyDown(KeyCode.Space)) {
                    if(skipPressOnce) {
                        Debug.Log("Skip init.");
                    } else {
                        skipText.gameObject.SetActive(true);
                        skipPressOnce = true;
                    }
                }

            }

        } else if(currentState == EntryCutscene.AWAKE) {

            

        } else if(currentState == EntryCutscene.EXIT) {
            StartCoroutine(PlayExitAnimation());
        }

    }

    private IEnumerator PlayEntryAnimation() {

        yield return new WaitForSeconds(3);
        monologueText.text = "...";
        yield return new WaitForSeconds(3);
        monologueText.text = "";
        yield return new WaitForSeconds(3);
        monologueText.text = "Where am I?...";
        yield return new WaitForSeconds(3);
        monologueText.text = "";
        yield return new WaitForSeconds(3);
        monologueText.text = "...";
        yield return new WaitForSeconds(3);
        monologueText.text = "";
        yield return new WaitForSeconds(3);
        dialogueText.text = "Hey!...";
        yield return new WaitForSeconds(3);
        dialogueText.text = "";
        yield return new WaitForSeconds(3);
        monologueText.text = "What?...";
        yield return new WaitForSeconds(3);
        monologueText.text = "";
        yield return new WaitForSeconds(3);
        monologueText.text = "Is anybody there?...";
        yield return new WaitForSeconds(3);
        monologueText.text = "";
        yield return new WaitForSeconds(3);
        dialogueText.text = "Wake up!...";
        yield return new WaitForSeconds(3);
        dialogueText.text = "";
        yield return new WaitForSeconds(2);
        dialogueText.text = "Okay, this doesn't seem to work...";
        yield return new WaitForSeconds(3);
        dialogueText.text = "";
        yield return new WaitForSeconds(1);
        dialogueText.text = "I'm going to re-initialize your system. Please wait...";
        yield return new WaitForSeconds(5);
        dialogueText.text = "";
        yield return new WaitForSeconds(3);
        dialogueText.text = "Okay... This could hurt a little...";
        yield return new WaitForSeconds(3);
        dialogueText.text = "";
        yield return new WaitForSeconds(2);
        dialogueText.text = "I'm going to reboot you now, please don't do ANYTHING. Got it?";
        yield return new WaitForSeconds(5);
        dialogueText.text = "";
        yield return new WaitForSeconds(2);
        dialogueText.text = "Good. I hope this won't damage your kernel...";
        yield return new WaitForSeconds(4);
        dialogueText.text = "";
        yield return new WaitForSeconds(5);

        currentState = EntryCutscene.AWAKE;

    }

    private IEnumerator PlayAwakeAnimation() {

        

        currentState = EntryCutscene.EXIT;

        yield return null;

    }

    private IEnumerator PlayExitAnimation() {

        yield return null;

    }

}
