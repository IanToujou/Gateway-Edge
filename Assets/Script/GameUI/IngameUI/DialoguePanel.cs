using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour {
    
    [SerializeField] private Text dialogueText;
    [SerializeField] private Text speakerText;

    void Awake() {
        gameObject.SetActive(false);
    }

}
