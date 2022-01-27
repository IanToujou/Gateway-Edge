using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionExitConfirmationUI : MonoBehaviour {

    void OnEnable() {
        foreach(Button all in GetComponentsInChildren<Button>()) {
            all.GetComponentInChildren<Text>().color = Color.white;
        }
    }

    public void ButtonPressYes() {
        SceneManager.LoadScene("SceneMenu");
    }

    public void ButtonPressNo() {
        LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_1);
    }
}
