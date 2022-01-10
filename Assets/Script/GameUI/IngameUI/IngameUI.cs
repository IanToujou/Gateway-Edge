using UnityEngine;

public class IngameUI : MonoBehaviour {
    
    [SerializeField] private GameObject dialoguePanel;

    void Start() {
        LevelManager.GetCurrentManager().GetDialogueManager().SetActiveDialogue(IngameDialogue.LEVEL_1_START);
    }

}
