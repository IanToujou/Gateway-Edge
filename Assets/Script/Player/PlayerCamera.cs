using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    
    [SerializeField] private float minDistance = 5.0f;
    [SerializeField] private float maxDistance = 15.0f;
    [SerializeField] private GameObject cameraFocus;
    [SerializeField] private float speed;

    void FixedUpdate() {

        Vector3 currentPosition = gameObject.transform.position;
        Vector3 playerPosition = cameraFocus.transform.position;

        float distance = Vector3.Distance(currentPosition, playerPosition);

        if(distance >= minDistance && distance <= maxDistance) {
            gameObject.transform.position = Vector3.Lerp(currentPosition, new Vector3(playerPosition.x, currentPosition.y, playerPosition.z), Time.deltaTime * speed);
        }
        
        gameObject.transform.LookAt(playerPosition);
        
    }

}
