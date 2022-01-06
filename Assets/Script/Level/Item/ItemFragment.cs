using UnityEngine;

public class ItemFragment : MonoBehaviour {

    private LevelManager manager;

    void Awake() {
        manager = LevelManager.GetManager("Zone1_Level1");
    }

    void FixedUpdate() {
        transform.RotateAround(transform.position, Vector3.up, 150 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Player")) {
            Debug.Log("Penis");
            manager.AddFragment(1);
            Destroy(gameObject);
        }
    }

}
