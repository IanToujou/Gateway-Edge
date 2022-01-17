using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneUI : MonoBehaviour {

    [SerializeField] private int zoneNumber;
    [SerializeField] private List<GameObject> levelButtons = new List<GameObject>();

    void Start() {

        SaveManager saveManager = SaveManager.GetInstance();        

        for(int i = 1; i <= levelButtons.Count; i++) {
            Debug.Log((zoneNumber-1)*6 + i);
            if(saveManager.GetCurrentSave().IsLevelCompleted((zoneNumber-1)*6 + i)) {
                levelButtons[i-1].GetComponentInChildren<Text>().color = new Color(0, 1, 0, 1);
            } else {
                levelButtons[i-1].GetComponentInChildren<Text>().color = new Color(0.2f, 0.2f, 0.2f, 1);
            }
        }

    }

}
