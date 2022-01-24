using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour {
    
    [SerializeField] private PlayerController playerController;
    [SerializeField] private string levelId;
    [SerializeField] private Text fragmentText;
    [SerializeField] private Text playerHealthText;
    [SerializeField] private Text timerText;
    [SerializeField] private Text protocolText;
    [SerializeField] private Text lapText;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private DeathPanel deathPanel;
    [SerializeField] private float timeLimit;
    [SerializeField] private int laps;
    [SerializeField] private List<IntersectionEventZone> intersectionZones;

    private static LevelManager instance;
    private GameObject player;
    private int fragments;
    private bool teleporterActive;
    private bool timerActive;
    private float timerTime;
    private bool protocolCollected;
    private int levelIdNumber;
    private int currentLap;
    private int timerCollected;

    void Awake() {
        currentLap = 1;
        instance = this;
        fragments = 0;
        teleporterActive = true;
        player = GameObject.FindGameObjectWithTag("Player");
        timerActive = false;
        timerTime = timeLimit;
        protocolCollected = false;
        timerCollected = 0;
        levelIdNumber = Int32.Parse(levelId.Substring(6));
        if(levelIdNumber == 1) playerController.SetFreezed(true);
    }

    void Start() {
        StartLevel();
    }

    void Update() {

        fragmentText.text = "" + fragments;
        playerHealthText.text = "" + playerController.GetPlayerHealth();
        if(protocolCollected) protocolText.color = new Color(0, 255, 0, 1);
        if(laps != 0) lapText.text = "Lap 0x0" + currentLap;

        if(timerActive) {

            timerTime -= Time.deltaTime;
            TimeSpan t = TimeSpan.FromSeconds(timerTime);
            string answer = string.Format("{0:D2}:{1:D2}:{2:D3}", t.Minutes, t.Seconds, t.Milliseconds);
            timerText.text = answer;

            if(timerTime <= 0.1f) {
                StopTimer();
                playerController.DieInstantly();
            }

        }

    }

    public void StartLevel() {
        dialogueManager.SetActiveDialogue(IngameDialogue.GetStartDialogue(levelIdNumber));
    }

    public void EndLevel() {
        if(currentLap < laps) {
            currentLap++;
            foreach(IntersectionEventZone zones in intersectionZones) {
                zones.SetState(1);
            }
            return;
        }
        Debug.Log("Saved completion of level " + levelIdNumber + " to the current save file.");
        SaveManager.GetInstance().GetSave().AddFragments(fragments);
        SaveManager.GetInstance().GetSave().SetLevelCompleted(levelIdNumber);
        if(protocolCollected) SaveManager.GetInstance().GetSave().SetProtocolCollected(levelIdNumber);
        SaveManager.GetInstance().GetSave().SetCompletionTime(levelIdNumber, Mathf.Abs(timeLimit - (timerTime-timerCollected*5)));
        SaveManager.GetInstance().Save();
        dialogueManager.SetActiveDialogue(IngameDialogue.GetEndDialogue(levelIdNumber));
        StartCoroutine(DestroyDelayed(1f));
    }

    public void PlayerDeath() {
        deathPanel.Animate();
    }

    public void ResetTimer() {
        timerTime = timeLimit;
    }

    public void StopTimer() {
        SetTimerActive(false);
    }

    public void StartTimer() {
        SetTimerActive(true);
    }

    public void CollectTimer() {
        timerTime += 5;
        timerCollected += 1;
    }

    public void AddTime(int amount) {
        timerTime += amount;
    }

    public void RemoveTime(int amount) {
        timerTime -= amount;
    }

    public void SetTime(int amount) {
        this.timerTime = amount;
    }

    public void CollectProtocol() {
        this.protocolCollected = true;
    }

    public IEnumerator DestroyDelayed(float delay) {
        yield return new WaitForSeconds(delay);
        DestroyManager();
    }

    public void DestroyManager() {
        instance = null;
    }

    public static LevelManager GetCurrentManager() {
        return instance;
    }

    public void AddFragment(int amount) {
        fragments += amount;
    }

    public static void LoadLevel(string id) {
        SceneManager.LoadScene("Scene" + id.Replace("_", ""));
    }

    public void ActivateTeleporter() {
        StartCoroutine(DelayTeleporterActivation());
    }

    public IEnumerator DelayTeleporterActivation() {
        teleporterActive = false;
        yield return new WaitForSeconds(1.5f);
        teleporterActive = true;
    }

    public bool IsTeleporterActive() {
        return teleporterActive;
    }

    public DialogueManager GetDialogueManager() {
        return dialogueManager;
    }

    public void SetDialogueManager(DialogueManager dialogueManager) {
        this.dialogueManager = dialogueManager;
    }

    public GameObject GetPlayer() {
        return player;
    }

    public PlayerController GetPlayerController() {
        return playerController;
    }

    public bool IsTimerActive() {
        return timerActive;
    }

    public void SetTimerActive(bool timerActive) {
        this.timerActive = timerActive;
    }

    public string GetLevelId() {
        return levelId;
    }

}
