using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameUI : MonoBehaviour {

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("SceneLevelSelection");
        }
    }

}
