using UnityEngine;

public class BrakingPad : MonoBehaviour {

    void OnTriggerEnter(Collider collider) {

        if(collider.CompareTag("Player")) {
            
            LevelManager.GetCurrentManager().GetPlayerController().SetBrakingPad(true);

        }

    }

    void OnTriggerExit(Collider collider) {

        if(collider.CompareTag("Player")) {
            
            LevelManager.GetCurrentManager().GetPlayerController().SetBrakingPad(false);

        }

    }
    
}
