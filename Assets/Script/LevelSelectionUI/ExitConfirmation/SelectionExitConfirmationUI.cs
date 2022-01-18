using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionExitConfirmationUI : MonoBehaviour
{
    public void ButtonPressYes() {
        SceneManager.LoadScene("SceneMenu");
    }

    public void ButtonPressNo() {
        LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_1);
    }
}
