using UnityEngine;

public class TutorialEventZone : MonoBehaviour {

    [SerializeField] private TutorialManager tutorialManager;
    [SerializeField] private int newState;

    void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Player")) {
            tutorialManager.SetState(newState);
        }
    }

}
