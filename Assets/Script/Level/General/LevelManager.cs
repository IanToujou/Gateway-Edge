using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour {
    
    [SerializeField] private string levelId;
    [SerializeField] private Text fragmentText;
    [SerializeField] private Text playerHealthText;
    [SerializeField] private Text timerText;
    [SerializeField] private Text protocolText;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private DeathPanel deathPanel;
    [SerializeField] private float timeLimit;

    private static LevelManager instance;
    private GameObject player;
    private int fragments;
    private bool teleporterActive;
    private bool timerActive;
    private float timerTime;
    private bool protocolCollected;

    void Awake() {
        instance = this;
        fragments = 0;
        teleporterActive = true;
        player = GameObject.FindGameObjectWithTag("Player");
        timerActive = false;
        timerTime = timeLimit;
        protocolCollected = false;
    }

    void Start() {
        StartLevel();
    }

    void Update() {

        fragmentText.text = "" + fragments;
        playerHealthText.text = "" + GetPlayerController().GetPlayerHealth();
        if(protocolCollected) protocolText.color = new Color(0, 255, 0, 1);

        if(timerActive) {

            timerTime -= Time.deltaTime;
            TimeSpan t = TimeSpan.FromSeconds(timerTime);
            string answer = string.Format("{0:D2}:{1:D2}:{2:D3}", t.Minutes, t.Seconds, t.Milliseconds);
            timerText.text = answer;

            if(timerTime <= 0.0f) {
                StopTimer();
            }

        }

    }

    public void StartLevel() {
        dialogueManager.SetActiveDialogue(IngameDialogue.LEVEL_1_START);
    }

    public void EndLevel() {
        SaveManager.GetInstance().GetCurrentSave().fragments += fragments;
        SaveManager.GetInstance().GetCurrentSave().SetLevelCompleted(1);
        if(protocolCollected) SaveManager.GetInstance().GetCurrentSave().SetProtocolCollected(1);
        SaveManager.GetInstance().SaveCurrent();
        dialogueManager.SetActiveDialogue(IngameDialogue.LEVEL_1_END);
        Destroy();
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

    public void Destroy() {
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
        return player.GetComponent<PlayerController>();
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
