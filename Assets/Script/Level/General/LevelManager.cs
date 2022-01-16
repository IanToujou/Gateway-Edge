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
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private DeathPanel deathPanel;
    [SerializeField] private float timeLimit;

    private static LevelManager instance;
    private GameObject player;
    private int fragments;
    private bool teleporterActive;
    private bool timerActive;
    private float timerTime;

    void Awake() {
        instance = this;
        fragments = 0;
        teleporterActive = true;
        player = GameObject.FindGameObjectWithTag("Player");
        timerActive = false;
        timerTime = timeLimit;
    }

    void Start() {
        StartLevel();
    }

    void Update() {

        fragmentText.text = "Fragments: " + fragments;
        playerHealthText.text = "HP: " + GetPlayerController().GetPlayerHealth();

        if(timerActive) {

            timerTime -= Time.deltaTime;

            string timeString = timerTime.ToString();
            Debug.Log(timeString);
            string seconds = timeString.Substring(0, 2);
            string millis = timeString.Substring(2, 3);

            TimeSpan t = TimeSpan.FromSeconds(timerTime);

            string answer = string.Format("{0:D2}:{1:D2}:{2:D3}", 
            t.Minutes, 
            t.Seconds, 
            t.Milliseconds);

            //timerText.text = Mathf.Floor(timerTime/60) + ":" + seconds + ":" + millis + ":00";
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
        dialogueManager.SetActiveDialogue(IngameDialogue.LEVEL_1_END);
        SaveManager.GetInstance().GetCurrentSave().fragments += fragments;
        SaveManager.GetInstance().GetCurrentSave().level_1_completed = true;
        SaveManager.GetInstance().SaveCurrent();
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

}
