using UnityEngine;

public class TeleporterPad : MonoBehaviour {

    [SerializeField] private GameObject destinationTeleporter;

    void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Player")) {
            Debug.Log(collider.gameObject.name);
        }
    }

}
