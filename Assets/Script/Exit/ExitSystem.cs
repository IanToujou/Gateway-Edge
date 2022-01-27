using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitSystem : MonoBehaviour {
    
    [SerializeField] private Text text;
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
        currentState = ExitCutscene.CREDITS;
    }

    void Start() {
        skipText.gameObject.SetActive(false);
        overlayPanel.gameObject.SetActive(false);
    }

    void Update() {

        if(currentState == ExitCutscene.CREDITS) {

            if(!playing) {

                playing = true;
                StartCoroutine(PlayCreditsAnimation());

            } else {

                if(Input.GetKeyDown(KeyCode.Space)) {
                    if(skipPressOnce) {
                        StopAllCoroutines();
                        currentState = ExitCutscene.ANIMATION;
                        playing = false;
                    } else {
                        skipText.gameObject.SetActive(true);
                        skipPressOnce = true;
                    }
                }

            }

        } else if(currentState == ExitCutscene.ANIMATION) {
            StartCoroutine(PlayAnimateAnimation());
        } else if(currentState == ExitCutscene.EXIT) {
            StartCoroutine(PlayExitAnimation());
        }

    }

    private IEnumerator PlayCreditsAnimation() {

        //Pre Delay
        audioSource.Play();
        yield return new WaitForSeconds(3);

        //Text
        ShowText(text, "You escape from the computer and made your way outside the simulation.", 3);
        yield return new WaitForSeconds(5);

        //Delay
        yield return new WaitForSeconds(3);

        //Text
        ShowText(text, "Made by Toujou Studios", 3);
        yield return new WaitForSeconds(3);

        //Delay
        yield return new WaitForSeconds(3);

        //Text
        ShowText(text, "Developer: Ian Bour", 2);
        yield return new WaitForSeconds(3);

        //Delay
        yield return new WaitForSeconds(3);

        //Text
        ShowText(text, "Artist: Sophie Zheng", 2);
        yield return new WaitForSeconds(3);

        //Delay
        yield return new WaitForSeconds(3);

        //Text
        ShowText(text, "3D Modelling: Ian Bour, Sophie Zheng", 2);
        yield return new WaitForSeconds(3);

        //Delay
        yield return new WaitForSeconds(3);

        //Text
        ShowText(text, "Story: Ian Bour", 2);
        yield return new WaitForSeconds(3);

        //Delay
        yield return new WaitForSeconds(3);

        //Text
        ShowText(text, "Music by: TeknoAxe, BrokenSound, Banshee, DJ Ten, White Bat Audio", 3);
        yield return new WaitForSeconds(5);

        //Delay
        yield return new WaitForSeconds(3);

        //Text
        ShowText(text, "Thank you for playing!", 2);
        yield return new WaitForSeconds(3);

        //Post Delay
        yield return new WaitForSeconds(3);
        currentState = ExitCutscene.ANIMATION;

    }

    private IEnumerator PlayAnimateAnimation() {

        overlayPanel.gameObject.SetActive(true);
        StartCoroutine(FadeOverlay());
        yield return new WaitForSeconds(3f);
        currentState = ExitCutscene.EXIT;

    }

    private IEnumerator PlayExitAnimation() {
        
        SceneManager.LoadScene("SceneMenu");
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
        text.text = "";

    }

}
