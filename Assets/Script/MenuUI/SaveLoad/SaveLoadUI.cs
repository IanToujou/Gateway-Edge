using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveLoadUI : MonoBehaviour {
    
    [SerializeField] private GameObject loadButton;
    [SerializeField] private GameObject newGameButton;
    [SerializeField] private GameObject continueGameButton;
    [SerializeField] private Image overlayPanel;

    private int selectedSave;
    private Text loadButtonText;
    private bool loadActive;
    private SaveManager saveManager;
    private UISoundManager soundManager;

    void Awake() {
        loadActive = false;
        overlayPanel.gameObject.SetActive(false);
        selectedSave = 0;
        loadButtonText = loadButton.GetComponentInChildren<Text>();
        saveManager = SaveManager.GetInstance();
        soundManager = UISoundManager.GetInstance();
    }

    void OnEnable() {
        foreach(Button all in GetComponentsInChildren<Button>()) {
            all.GetComponentInChildren<Text>().color = Color.white;
        }
    }

    void Start() {
        if(saveManager.GetSave().IsSaveActive()) {
            continueGameButton.GetComponentInChildren<Text>().color = new Color(1, 1, 1, 1f);
        } else {
            continueGameButton.GetComponentInChildren<Text>().color = new Color(1, 1, 1, 0.3f);
        }
    }

    void Update() {

        if(selectedSave > 0) {
            loadButtonText.color = new Color(1, 1, 1, 1);
            loadActive = true;
        } else {
            loadButtonText.color = new Color(1, 1, 1, 0.3f);
            loadActive = false;
        }

        if(selectedSave == 1) {
            newGameButton.GetComponentInChildren<Text>().color = Color.cyan;
            if(saveManager.GetSave().IsSaveActive()) continueGameButton.GetComponentInChildren<Text>().color = new Color(1f, 1f, 1f, 1f);
        } else if(selectedSave == 2) {
            if(saveManager.GetSave().IsSaveActive()) continueGameButton.GetComponentInChildren<Text>().color = Color.cyan;
            newGameButton.GetComponentInChildren<Text>().color = new Color(1f, 1f, 1f, 1f);
        }
        
    }

    public void ButtonPressBack() {
        UISoundManager.GetInstance().PlayAudioClip(UISoundClipList.SFX_UI_CLICK);
        MenuUIManager.SetActiveCanvas(MenuUILayout.MENU);
    }

    public void ButtonPressNew() {
        selectedSave = 1;
        UISoundManager.GetInstance().PlayAudioClip(UISoundClipList.SFX_UI_CLICK);
    }

    public void ButtonPressContinue() {
        if(!saveManager.GetSave().IsSaveActive()) return;
        selectedSave = 2;
        UISoundManager.GetInstance().PlayAudioClip(UISoundClipList.SFX_UI_CLICK);
    }

    public void ButtonPressLoad() {
        
        if(!loadActive) return;
        overlayPanel.gameObject.SetActive(true);
        UISoundManager.GetInstance().PlayAudioClip(UISoundClipList.SFX_UI_CLICK);
        StartCoroutine(FadeOverlay());

    }

    private IEnumerator FadeOverlay() {

        for (float i = 0; i <= 1; i += Time.deltaTime) {
            overlayPanel.color = new Color(0, 0, 0, i);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        if(selectedSave == 2) {
            SceneManager.LoadScene("SceneLevelSelection");
        } else {
            SceneManager.LoadScene("SceneEntry");
        }

    }

}
