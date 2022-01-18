using UnityEngine;
using System.Collections.Generic;

public class LevelSelectionUIManager : MonoBehaviour {

    [SerializeField] private GameObject zone1UI;
    [SerializeField] private GameObject zone2UI;
    [SerializeField] private GameObject zone3UI;
    [SerializeField] private GameObject zone4UI;
    [SerializeField] private GameObject exitConfirmationUI;
    
    private static List<GameObject> uiList = new List<GameObject>();
    

    void Awake() {
        uiList.Add(zone1UI);
        uiList.Add(zone2UI);
        uiList.Add(zone3UI);
        uiList.Add(zone4UI);
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
