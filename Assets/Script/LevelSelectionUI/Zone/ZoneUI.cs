using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneUI : MonoBehaviour {

    [SerializeField] private int zoneNumber;
    [SerializeField] private List<GameObject> levelButtons = new List<GameObject>();

    void Start() {

        SaveManager saveManager = SaveManager.GetInstance();

        for(int i = 1; i <= levelButtons.Count; i++) {
            if(saveManager.GetCurrentSave().IsLevelCompleted((zoneNumber-1)*6 + i)) {
                levelButtons[i-1].GetComponentInChildren<Text>().color = new Color(0, 1, 0, 1);
            } else {
                levelButtons[i-1].GetComponentInChildren<Text>().color = new Color(0.2f, 0.2f, 0.2f, 1);
            }
        }

    }

    public void ButtonPressBack() {
        if(zoneNumber == 2) LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_1);
        if(zoneNumber == 3) LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_2);
        if(zoneNumber == 4) LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_3);
    }

    public void ButtonPressNext() {
        if(zoneNumber == 1) LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_2);
        if(zoneNumber == 2) LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_3);
        if(zoneNumber == 3) LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_4);
    }

    public void ButtonPressExit() {
        LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.EXIT_CONFIRMATION);
    }

}
