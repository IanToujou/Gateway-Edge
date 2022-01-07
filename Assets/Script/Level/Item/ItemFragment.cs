using UnityEngine;

public class ItemFragment : MonoBehaviour {

    private LevelManager manager;

    void Awake() {
        manager = LevelManager.GetCurrentManager();
    }

    void FixedUpdate() {
        transform.RotateAround(transform.position, Vector3.up, 150 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Player")) {
            manager.AddFragment(1);
            Destroy(gameObject);
        }
    }

}
