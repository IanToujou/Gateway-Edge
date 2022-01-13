using UnityEngine;

public class DialogueEventZone : MonoBehaviour {
    
    [SerializeField] private int dialogueId;

    void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Player")) {
            LevelManager.GetCurrentManager().GetDialogueManager().SetActiveDialogue(dialogueId);
        }
    }

}
