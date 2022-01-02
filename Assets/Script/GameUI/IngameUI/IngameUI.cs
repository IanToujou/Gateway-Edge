using UnityEngine;

public class IngameUI : MonoBehaviour {
    
    [SerializeField] private GameObject dialoguePanel;

    void Awake() {
        dialoguePanel.SetActive(false);
    }

    void Start() {
        DialoguePanel.SetActiveDialogue(-1);
    }

}
