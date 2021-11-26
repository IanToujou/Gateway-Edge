using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject child;
    [SerializeField] private float speed;

    void FixedUpdate() {
        gameObject.transform.position = Vector3.Lerp(transform.position, child.transform.position, Time.deltaTime * speed);
        gameObject.transform.LookAt(child.transform.position);
    }

}
