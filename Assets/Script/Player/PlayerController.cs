using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] private CharacterController controller;
    [SerializeField] private float baseSpeed = 1.0f;
    [SerializeField] private float rotationSpeed = 1.5f;
    [SerializeField] private float boostSpeed = 1.5f;
    [SerializeField] private float brakeForce = 2.0f;
    [SerializeField] private float maxSpeed = 20.0f;
    [SerializeField] private float minSpeed = 0.5f;

    void FixedUpdate() {
        
        float z = baseSpeed / 100;

        Vector3 direction = new Vector3(0, 0, z);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal >= 0.05f || horizontal <= -0.05f) {

            //Rotate player

        }

        controller.Move(direction);
        
    }

}
