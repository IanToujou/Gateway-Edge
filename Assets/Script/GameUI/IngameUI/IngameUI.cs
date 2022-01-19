using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameUI : MonoBehaviour {
    
    [SerializeField] private GameObject dialoguePanel;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("SceneLevelSelection");
        }
    }

}
