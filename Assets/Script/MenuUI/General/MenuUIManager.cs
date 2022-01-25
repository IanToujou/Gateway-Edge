using UnityEngine;
using System.Collections.Generic;

public class MenuUIManager : MonoBehaviour{

    [SerializeField] private GameObject bootUI;
    [SerializeField] private GameObject titleUI;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject exitConfirmationUI;
    [SerializeField] private GameObject saveLoadUI;
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private GameObject musicUI;
    [SerializeField] private GameObject creditsUI;
    
    private static List<GameObject> uiList;
    
    void OnEnable() {
        uiList = new List<GameObject>();
        uiList.Add(bootUI);
        uiList.Add(titleUI);
        uiList.Add(menuUI);
        uiList.Add(exitConfirmationUI);
        uiList.Add(saveLoadUI);
        uiList.Add(settingsUI);
        uiList.Add(musicUI);
        uiList.Add(creditsUI);
        DeactivateAllCanvas();
    }

    public static void SetActiveCanvas(int layout) {

        DeactivateAllCanvas();
        uiList[layout].SetActive(true);

    }

    public static void DeactivateAllCanvas() {
        foreach(GameObject all in uiList) {
            all.SetActive(false);
        }
    }
    
}
