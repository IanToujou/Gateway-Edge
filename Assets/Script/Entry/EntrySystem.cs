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

        //Pre Delay
        audioSource.Play();
        yield return new WaitForSeconds(3);

        //Text
        ShowText(monologueText, "[Me] ...", 3);
        yield return new WaitForSeconds(4);

        //Delay
        yield return new WaitForSeconds(3);

        //Text
        ShowText(monologueText, "[Me] Where am I?...", 3);
        yield return new WaitForSeconds(4);

        //Delay
        yield return new WaitForSeconds(3);

        //Text
        ShowText(dialogueText, "[???] Hey!...", 3);
        yield return new WaitForSeconds(4);

        //Delay
        yield return new WaitForSeconds(3);

        //Text
        ShowText(monologueText, "[Me] What?...", 2);
        yield return new WaitForSeconds(3);

        //Delay
        yield return new WaitForSeconds(3);

        //Text
        ShowText(monologueText, "[Me] Is anybody there?...", 3);
        yield return new WaitForSeconds(4);

        //Delay
        yield return new WaitForSeconds(3);

        //Text
        ShowText(dialogueText, "[???] Wake up!...", 3);
        yield return new WaitForSeconds(4);

        //Delay
        yield return new WaitForSeconds(2);

        //Text
        ShowText(dialogueText, "[???] Okay, this doesn't seem to work...", 3);
        yield return new WaitForSeconds(4);

        //Delay
        yield return new WaitForSeconds(1);

        //Text
        ShowText(dialogueText, "[???] I'm going to re-initialize your system. Please wait...", 5);
        yield return new WaitForSeconds(6);

        //Delay
        yield return new WaitForSeconds(3);

        //Text
        ShowText(dialogueText, "[???] Okay... This could hurt a little...", 3);
        yield return new WaitForSeconds(4);

        //Delay
        yield return new WaitForSeconds(2);

        //Text
        ShowText(dialogueText, "[???] I'm going to reboot you now, please don't do ANYTHING. Got it?", 5);
        yield return new WaitForSeconds(6);

        //Delay
        yield return new WaitForSeconds(2);

        //Text
        ShowText(dialogueText, "[???] Good. I hope this won't damage you...", 4);
        yield return new WaitForSeconds(5);

        //Post Delay
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

    private void ShowText(Text text, string textString, int seconds) {
        StartCoroutine(ShowTextAnimated(text, textString, seconds));
    }

    private IEnumerator ShowTextAnimated(Text text, string textString, int seconds) {

        text.text = textString;
        StartCoroutine(FadeText(text, true));
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(seconds);
        StartCoroutine(FadeText(text, false));
        yield return new WaitForSeconds(0.5f);

    }

}
