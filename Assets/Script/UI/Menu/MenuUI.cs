using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {

    public void ButtonPressStart() {
        SceneManager.LoadScene("SceneSaveLoad");
    }

    public void ButtonPressExit() {
        Application.Quit();
    }

    public void ButtonPressSettings() {
        UIManager.SetActiveCanvas(UILayout.SETTINGS);
    }

}
