using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveLoadUI : MonoBehaviour {
    
    [SerializeField] private GameObject loadButton;
    [SerializeField] private List<GameObject> saves;
    [SerializeField] private Image overlayPanel;

    private int selectedSave;
    private Text loadButtonText;
    private bool loadActive;
    private SaveManager saveManager;

    void Awake() {
        loadActive = false;
        overlayPanel.gameObject.SetActive(false);
        selectedSave = 0;
        loadButtonText = loadButton.GetComponentInChildren<Text>();
        saveManager = SaveManager.GetInstance();
    }

    void Start() {

        for(int i = 1; i <= saves.Count; i++) {
            GameObject currentSave = saves[i-1];
            if(saveManager.GetSave(i).IsSaveActive()) {
                currentSave.GetComponentInChildren<Text>().text = "Save " + i + ": Data Found";
            } else {
                currentSave.GetComponentInChildren<Text>().text = "Save " + i + ": No Data";
            }
        }

    }

    void Update() {

        if(selectedSave > 0) {
            loadButtonText.color = new Color(255, 255, 255, 1);
            loadActive = true;
        } else {
            loadButtonText.color = new Color(255, 255, 255, 0.3f);
            loadActive = false;
        }
        
    }

    public void ButtonPressBack() {
        MenuUIManager.SetActiveCanvas(MenuUILayout.MENU);
    }

    public void ButtonPressLoad() {

        if(!loadActive) return;
        overlayPanel.gameObject.SetActive(true);
        StartCoroutine(FadeOverlay());

    }

    public void SelectSave(int saveNumber) {

        selectedSave = saveNumber;

        foreach(GameObject allSaves in saves) {
            allSaves.GetComponentInChildren<Text>().color = Color.white;
        }

        GameObject currentSave = saves[saveNumber-1];
        Text currentSaveText = currentSave.GetComponentInChildren<Text>();
        currentSaveText.color = Color.cyan;
        
    }

    private IEnumerator FadeOverlay() {

        for (float i = 0; i <= 1; i += Time.deltaTime) {
            overlayPanel.color = new Color(0, 0, 0, i);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        if(saveManager.GetSave(selectedSave).IsSaveActive()) {
            saveManager.Load(selectedSave);
            SceneManager.LoadScene("SceneLevelSelection");
        } else {
            SceneManager.LoadScene("SceneEntry");
        }

    }

}
