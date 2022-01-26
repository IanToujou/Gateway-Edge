using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationRotation : MonoBehaviour {
    
    [SerializeField] private bool rotationActive;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform rotationPoint;

    void FixedUpdate() {
        if(rotationPoint == null) return;
        if(rotationActive) {
            transform.RotateAround(rotationPoint.position, Vector3.up, 10 * rotationSpeed * Time.deltaTime);
        }
    }

}
