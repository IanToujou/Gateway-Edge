using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour{

    [SerializeField] private GameObject bootUI;
    [SerializeField] private GameObject titleUI;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject exitConfirmationUI;
    [SerializeField] private GameObject saveLoadUI;
    [SerializeField] private GameObject settingsUI;
    
    private static List<GameObject> uiList = new List<GameObject>();
    

    void Awake() {
        uiList.Add(bootUI);
        uiList.Add(titleUI);
        uiList.Add(menuUI);
        uiList.Add(exitConfirmationUI);
        uiList.Add(saveLoadUI);
        uiList.Add(settingsUI);
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
