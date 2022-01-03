using UnityEngine;

public class IngameUI : MonoBehaviour {
    
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private DialogueManager dialogueManager;

    void Start() {
        dialogueManager.SetActiveDialogue(IngameDialogue.LEVEL_1_START);
    }

}
