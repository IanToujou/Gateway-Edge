using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadUI : MonoBehaviour {
    
    [SerializeField] private GameObject loadButton;

    private int selectedSave;
    private Text loadButtonText;

    void Awake() {
        selectedSave = 0;
        loadButtonText = loadButton.GetComponentInChildren<Text>();
    }

    void Update() {
        if(selectedSave > 0) {
            loadButtonText.color = new Color(255, 255, 255, 1);
        } else {
            loadButtonText.color = new Color(50, 50, 50, 1);
        }
    }

    public void ButtonPressBack() {
        UIManager.SetActiveCanvas(UILayout.MENU);
    }

    public void ButtonPressLoad() {
        UIManager.SetActiveCanvas(UILayout.MENU);
    }

    public void SelectSave(int saveNumber) {
        selectedSave = saveNumber;
    }

}
