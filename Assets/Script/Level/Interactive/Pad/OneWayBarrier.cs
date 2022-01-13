using System.Collections;
using UnityEngine;

public class OneWayBarrier : MonoBehaviour {
    
    [SerializeField] private GameObject colliderBox;

    void OnTriggerEnter(Collider collider) {

        if(collider.CompareTag("Player")) {
            colliderBox.SetActive(false);
            StartCoroutine(DelayDeactivation());
        }

    }
    
    public IEnumerator DelayDeactivation() {
        yield return new WaitForSeconds(3f);
        colliderBox.SetActive(true);
    }

}
