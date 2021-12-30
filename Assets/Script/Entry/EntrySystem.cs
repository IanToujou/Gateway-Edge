using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EntrySystem : MonoBehaviour {
    
    [SerializeField] private Text monologueText;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Text skipText;
    [SerializeField] private GameObject backgroundPanel;
    [SerializeField] private Image overlayPanel;
    [SerializeField] private AudioSource audioSource;

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
        overlayPanel.gameObject.SetActive(false);
    }

    void Update() {

        if(currentState == EntryCutscene.ENTRY) {

            if(!playing) {

                playing = true;
                StartCoroutine(PlayEntryAnimation());

            } else {

                if(Input.GetKeyDown(KeyCode.Space)) {
                    if(skipPressOnce) {
                        StopAllCoroutines();
                        currentState = EntryCutscene.AWAKE;
                        playing = false;
                    } else {
                        skipText.gameObject.SetActive(true);
                        skipPressOnce = true;
                    }
                }

            }

        } else if(currentState == EntryCutscene.AWAKE) {
            StartCoroutine(PlayAwakeAnimation());
        } else if(currentState == EntryCutscene.EXIT) {
            StartCoroutine(PlayExitAnimation());
        }

    }

    private IEnumerator PlayEntryAnimation() {

        audioSource.Play();
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

        overlayPanel.gameObject.SetActive(true);
        StartCoroutine(FadeOverlay());
        yield return new WaitForSeconds(5);
        currentState = EntryCutscene.EXIT;

    }

    private IEnumerator PlayExitAnimation() {

        LevelManager.LoadLevel("Level_1");
        yield return null;

    }

    private IEnumerator FadeOverlay() {

        for (float i = 0; i <= 1; i += Time.deltaTime) {
            overlayPanel.color = new Color(255, 255, 255, i);
            yield return null;
        }

    }

}
