using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    
    [SerializeField] private GameObject cameraFocus;

    void FixedUpdate() {

        Transform playerTransform = cameraFocus.transform;
        
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
        
    }

}
