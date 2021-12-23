using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {

    public void PressStart() {
        SceneManager.LoadScene("SceneSaveLoad");
    }

    public void PressExit() {
        Application.Quit();
    }

    public void PressOptions() {
        SceneManager.LoadScene("SceneOptions");
    }

}
