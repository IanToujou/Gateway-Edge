using System.Collections;
using UnityEngine;

public class TeleporterPad : MonoBehaviour {

    [SerializeField] private GameObject destinationTeleporter;
    private GameObject player;
    private LevelManager levelManager;

    void Start() {
        levelManager = LevelManager.GetCurrentManager();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Player")) {
            if(levelManager.IsTeleporterActive()) {
                player.transform.position = destinationTeleporter.transform.position;
                levelManager.ActivateTeleporter();
            }
        }
    }

}
