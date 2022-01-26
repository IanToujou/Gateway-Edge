using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneUI : MonoBehaviour {

    [SerializeField] private int zoneNumber;
    [SerializeField] private Text fragmentText;
    [SerializeField] private List<GameObject> levelButtons = new List<GameObject>();

    private Camera playerCamera;
    private ParticleSystem particles;
    private ParticleSystem.MainModule particleMainModule;
    private List<int> allowedToEnter = new List<int>();
    private SaveManager saveManager;

    void Start() {

        saveManager = SaveManager.GetInstance();
        Save save = saveManager.GetSave();
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        particles = GameObject.Find("BackgroundParticles").GetComponent<ParticleSystem>();
        particleMainModule = particles.main;
        particles.Clear();

        for(int i = 0; i < levelButtons.Count; i++) {

            int currentLevel = (zoneNumber-1)*3 + (i+1);
            levelButtons[i].GetComponentInChildren<Text>().text = "Level - " + zoneNumber + "." + (i+1);

            TimeSpan t = TimeSpan.FromSeconds(save.GetCompletionTime(currentLevel));
            string answer = string.Format("{0:D2}:{1:D2}:{2:D3}", t.Minutes, t.Seconds, t.Milliseconds);
            levelButtons[i].GetComponentsInChildren<Text>()[1].text = answer;

            if(save.IsLevelCompleted(currentLevel)) {
                levelButtons[i].GetComponentInChildren<Text>().color = new Color(0f, 1f, 0f, 1f);
                levelButtons[i].GetComponentsInChildren<Text>()[1].color = new Color(0f, 1f, 1f, 1f);
                if(save.IsProtocolCollected(currentLevel)) {
                    levelButtons[i].GetComponentsInChildren<Image>()[1].color = new Color(1f, 0.5f, 0f, 1f);
                } else {
                    levelButtons[i].GetComponentsInChildren<Image>()[1].color = new Color(0.2f, 0.2f, 0.2f, 1f);
                }
            } else {
                levelButtons[i].GetComponentsInChildren<Text>()[1].color = new Color(0.2f, 0.2f, 0.2f, 1f);
                levelButtons[i].GetComponentsInChildren<Image>()[1].color = new Color(0.2f, 0.2f, 0.2f, 1f);
                if(save.IsLevelCompleted(currentLevel-1) || currentLevel == 1) {
                    levelButtons[i].GetComponentInChildren<Text>().color = new Color(1f, 1f, 0f, 1f);
                } else {
                    levelButtons[i].GetComponentInChildren<Text>().color = new Color(0.2f, 0.2f, 0.2f, 1f);
                }
            }

        }

        fragmentText.text = "" + save.GetFragments();

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
        }
    }

    public void ButtonPressLevel(int levelNumber) {
        if(SaveManager.GetInstance().GetSave().IsLevelCompleted(levelNumber-1) || SaveManager.GetInstance().GetSave().IsLevelCompleted(levelNumber) || levelNumber == 1) {
            UISoundManager.GetInstance().PlayAudioClip(UISoundClipList.SFX_UI_NOTIFICATION);
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
    }

    public void ButtonPressNext() {
        particles.Clear();
        if(zoneNumber == 1) {
            LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_2);
        }
        if(zoneNumber == 2) {
            LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.ZONE_3);
        }
    }

    public void ButtonPressExit() {
        LevelSelectionUIManager.SetActiveCanvas(LevelSelectionUILayout.EXIT_CONFIRMATION);
    }

}
