using UnityEngine;

public class TeleporterPad : MonoBehaviour {

    [SerializeField] private GameObject destinationTeleporter;
    [SerializeField] private GameObject player;
    private LevelManager levelManager;

    void Start() {
        levelManager = LevelManager.GetCurrentManager();
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Player")) {
            if(levelManager.IsTeleporterActive()) {
                player.GetComponentInChildren<TrailRenderer>().Clear();
                player.transform.position = destinationTeleporter.transform.position;
                levelManager.ActivateTeleporter();
            }
        }
    }

}
