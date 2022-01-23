using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneUI : MonoBehaviour {

    [SerializeField] private int zoneNumber;
    [SerializeField] private List<GameObject> levelButtons = new List<GameObject>();

    private Camera playerCamera;
    private ParticleSystem particles;
    private ParticleSystem.MainModule particleMainModule;
    private List<int> allowedToEnter = new List<int>();
    private UISoundManager soundManager;

    void Start() {

        SaveManager saveManager = SaveManager.GetInstance();
        //soundManager = UISoundManager.GetInstance();
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        particles = GameObject.Find("BackgroundParticles").GetComponent<ParticleSystem>();
        particleMainModule = particles.main;
        particles.Clear();

        Debug.Log("Completed levels: ");
        foreach(int level in saveManager.GetSave().GetCompletedLevels()) {
            Debug.Log(level);
        }

        for(int i = 1; i <= levelButtons.Count; i++) {
            levelButtons[i-1].GetComponentInChildren<Text>().text = "Level - " + zoneNumber + "." + i;
            if(saveManager.GetSave().IsLevelCompleted((zoneNumber-1)*6 + i)) {
                levelButtons[i-1].GetComponentInChildren<Text>().color = new Color(0, 1, 0, 1);
                levelButtons[i].GetComponentInChildren<Text>().color = new Color(1f, 1f, 0, 1);
                i++;
            } else {
                levelButtons[i-1].GetComponentInChildren<Text>().color = new Color(0.2f, 0.2f, 0.2f, 1);
            }
        }

    }

    void Update() {
        if(zoneNumber == 1) {
            LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_1);
            playerCamera.backgroundColor = new Color(0.2455351f, 0f, 0.3867925f, 0f);
            particleMainModule.startColor = new Color(1f, 0f, 0.5132675f, 1f);
        } else if(zoneNumber == 2) {
            LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_2);
            playerCamera.backgroundColor = new Color(0f, 0.03444649f, 0.245283f, 0f);
            particleMainModule.startColor = new Color(0f, 0.9696946f, 1f, 1f);
        } else if(zoneNumber == 3) {
            LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_3);
            playerCamera.backgroundColor = new Color(0f, 0.2641509f, 0.1088356f, 0f);
            particleMainModule.startColor = new Color(0.3039824f, 1f, 0.1556604f, 1f);
        } else if(zoneNumber == 4) {
            playerCamera.backgroundColor = new Color(1f, 0.3480333f, 0f, 0f);
            particleMainModule.startColor = new Color(0.9330316f, 1f, 0f, 1f);
        }
    }

    public void ButtonPressLevel(int levelNumber) {
        if(SaveManager.GetInstance().GetSave().IsLevelCompleted(levelNumber-1)) {
            //soundManager.PlayAudioClip(UISoundClipList.SFX_UI_NOTIFICATION);
            LevelManager.LoadLevel("Level_" + levelNumber);
        }
    }

    public void ButtonPressBack() {
        particles.Clear();
        if(zoneNumber == 2) {
            LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_1);
        }
        if(zoneNumber == 3) {
            LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_2);
        }
        if(zoneNumber == 4) {
            LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_3);
        }
    }

    public void ButtonPressNext() {
        particles.Clear();
        if(zoneNumber == 1) {
            LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_2);
        }
        if(zoneNumber == 2) {
            LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_3);
        }
        if(zoneNumber == 3) {
            LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_4);
        }
    }

    public void ButtonPressExit() {
        LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.EXIT_CONFIRMATION);
    }

}
