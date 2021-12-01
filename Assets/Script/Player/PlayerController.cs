    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] private float baseSpeed = 1.0f;
    [SerializeField] private float rotationSpeed = 1.5f;
    [SerializeField] private float boostSpeed = 1.5f;
    [SerializeField] private float brakeForce = 2.0f;
    [SerializeField] private float maxSpeed = 20.0f;
    [SerializeField] private float minSpeed = 0.5f;

    void FixedUpdate() {
        
        //Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 targetVector = new Vector3(horizontal, 0, vertical);
        Vector3 targetPosition = Quaternion.Euler(0, gameObject.transform.eulerAngles.y, 0) * targetVector;

        gameObject.transform.position = targetPosition;

        //Rotate towards moving direction
        Quaternion rotation = Quaternion.LookRotation(targetVector);
        transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, rotation, rotationSpeed);

    }

}
