using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleText : MonoBehaviour {

    private float alpha;
    private bool playingAnimation;
    private Text text;

    void Awake() {
        text = gameObject.GetComponent<Text>();
        alpha = 1;
        playingAnimation = false;
    }

    void Update() {
        if(!playingAnimation) {
            playingAnimation = true;
            StartCoroutine(PlayAnimation());
        }
    }

    private IEnumerator PlayAnimation() {
        if(alpha == 1) {
            while (text.color.a > 0.1) {
                text.color = Color.Lerp(text.color, new Color(255, 255, 255, 0), 3f * Time.deltaTime);
                yield return null;
            }
            alpha = 0;
        } else {
            while (text.color.a < 0.9) {
                text.color = Color.Lerp(text.color, new Color(255, 255, 255, 1), 3f * Time.deltaTime);
                yield return null;
            }
            alpha = 1;
        }
        playingAnimation = false;
    }
    
}
