using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] private CharacterController controller;
    [SerializeField] private float baseSpeed = 10.0f;

    void Update() {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        
        if(direction.magnitude >= 0.1f) {
            controller.Move(direction * baseSpeed * Time.deltaTime);
        }
        
    }

}
