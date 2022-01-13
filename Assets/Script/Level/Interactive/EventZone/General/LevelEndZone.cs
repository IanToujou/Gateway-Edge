using UnityEngine;

public class LevelEndZone : MonoBehaviour {
    
    void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Player")) {
            LevelManager.GetCurrentManager().EndLevel();
        }
    }

}
