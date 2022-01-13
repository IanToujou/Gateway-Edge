using UnityEngine;

public class BoosterPad : MonoBehaviour {

    void OnTriggerEnter(Collider collider) {

        if(collider.CompareTag("Player")) {
            
            LevelManager.GetCurrentManager().GetPlayerController().SetBoostingPad(true);

        }

    }

    void OnTriggerExit(Collider collider) {

        if(collider.CompareTag("Player")) {
            
            LevelManager.GetCurrentManager().GetPlayerController().SetBoostingPad(false);

        }

    }
    
}
