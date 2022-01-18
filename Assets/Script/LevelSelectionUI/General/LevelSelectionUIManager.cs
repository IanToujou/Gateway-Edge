using UnityEngine;
using System.Collections.Generic;

public class LevelSelectionUIManager : MonoBehaviour {

    [SerializeField] private GameObject zoneOneUI;
    [SerializeField] private GameObject zoneTwoUI;
    [SerializeField] private GameObject zoneThreeUI;
    [SerializeField] private GameObject zoneFourUI;
    [SerializeField] private GameObject exitConfirmationUI;
    
    private static List<GameObject> uiList = new List<GameObject>();
    

    void Awake() {
        uiList.Add(zoneOneUI);
        uiList.Add(zoneTwoUI);
        uiList.Add(zoneThreeUI);
        uiList.Add(zoneFourUI);
        uiList.Add(exitConfirmationUI);
    }

    void Start() {
        SetActiveCanvas(LevelSelectionUILayout.ZONE_1);
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
