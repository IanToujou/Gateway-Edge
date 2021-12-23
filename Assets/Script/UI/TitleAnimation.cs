using UnityEngine;
using UnityEngine.UI;

public class TitleAnimation : MonoBehaviour{

    [SerializeField] private Sprite titleOn;
    [SerializeField] private Sprite titleOff;
    [SerializeField] private int delay;
    [SerializeField] private int turnOffProbability;

    private int state;
    private Image titleImage;
    private int currentFrame;
    private bool waiting;

    void Start() {
        state = 1;
        titleImage = gameObject.GetComponent<Image>();
        currentFrame = -1;
        waiting = false;
    }

    void Update() {
        
        currentFrame++;

        //Wait for the animation delay, if not, fuck this shit I'm out.
        if(currentFrame >= delay) {
            waiting = false;
            currentFrame = 0;
        }
        if(waiting) return;
        if(currentFrame < delay) waiting = true;

        //Random funny numbers that I hope are better than Java randoms.
        System.Random random = new System.Random();
        int randomNumber = random.Next(100);

        //Randomize the current state.
        if(randomNumber <= turnOffProbability) {
            state = 0;
        } else {
            state = 1;
        }

        //Set the sprite depending on the state.
        if(state == 0) {
            titleImage.sprite = titleOff;
        } else {
            titleImage.sprite = titleOn;
        }

    }

}
