using UnityEngine;

public class ItemTimer : MonoBehaviour {
    
    private LevelManager manager;

    void Start() {
        manager = LevelManager.GetCurrentManager();
    }

    void FixedUpdate() {
        transform.RotateAround(transform.position, Vector3.forward, 150 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Player")) {
            manager.CollectTimer();
            Destroy(gameObject);
        }
    }

}
