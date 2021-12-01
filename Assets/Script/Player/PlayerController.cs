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
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        transform.Translate(direction * baseSpeed * Time.deltaTime, Space.World);
        
    }

}
