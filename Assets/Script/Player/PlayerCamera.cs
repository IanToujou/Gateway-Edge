using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    
    [SerializeField] private GameObject cameraFocus;

    void FixedUpdate() {

        //Get the player transform.
        Transform playerTransform = cameraFocus.transform;

        //Move the camera relative to the player's position.
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
        
    }

}
