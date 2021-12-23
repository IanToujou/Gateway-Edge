using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public void PressStart()
    {
        SceneManager.LoadScene("SceneLevelSelect");
    }

    public void PressExit()
    {
        Debug.Log("Button Pressed");
        Application.Quit();
    }

    public void PressOptions()
    {

    }
}
