using UnityEngine;

public class ItemFragment : MonoBehaviour {

    private LevelManager manager;

    void Awake() {
        manager = LevelManager.GetManager("Zone1_Level1");
    }

    void FixedUpdate() {
        transform.RotateAround(transform.position, Vector3.up, 150 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider target) {
        if(target.tag == "Player") {
            manager.AddFragment(1);
            Destroy(gameObject);
        }
    }

}
