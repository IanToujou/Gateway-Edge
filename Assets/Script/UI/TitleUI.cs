using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour{

    [SerializeField] private Sprite titleOn;
    [SerializeField] private Sprite titleOff;

    private int state;
    private Image titleImage;

    void Start() {
        state = 1;
        titleImage = gameObject.GetComponent<Image>();
    }

    void Update() {
        
        if(Input.GetKeyDown(KeyCode.W)) state = 0;

        if(state == 0) {
            titleImage.sprite = titleOff;
        } else {
            titleImage.sprite = titleOn;
        }

    }

}
