using System.Collections.Generic;
using UnityEngine;

public class IntersectionEventZone : MonoBehaviour {
    
    [SerializeField] private List<GameObject> firstState = new List<GameObject>();
    [SerializeField] private List<GameObject> secondState = new List<GameObject>();

    void Start() {
        SetState(1);
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Player")) {
            SetState(2);
        }
    }

    private void SetState(int state) {
        if(state == 1) {
            foreach(GameObject gameObject in secondState) {
                gameObject.SetActive(false);
            }
            foreach(GameObject gameObject in firstState) {
                gameObject.SetActive(true);
            }
        } else if(state == 2) {
            foreach(GameObject gameObject in firstState) {
                gameObject.SetActive(false);
            }
            foreach(GameObject gameObject in secondState) {
                gameObject.SetActive(true);
            }
        }
    }

}
