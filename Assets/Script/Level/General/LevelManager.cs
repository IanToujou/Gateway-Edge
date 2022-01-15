using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    [SerializeField] private string levelId;
    [SerializeField] private Text fragmentText;
    [SerializeField] private Text playerHealthText;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private DeathPanel deathPanel;

    private static LevelManager instance;
    private GameObject player;
    private int fragments;
    private bool teleporterActive;

    void Awake() {
        instance = this;
        fragments = 0;
        teleporterActive = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start() {
        StartLevel();
    }

    void Update() {
        fragmentText.text = "Fragments: " + fragments;
        playerHealthText.text = "HP: " + GetPlayerController().GetPlayerHealth();
    }

    public void StartLevel() {
        dialogueManager.SetActiveDialogue(IngameDialogue.LEVEL_1_START);
    }

    public void EndLevel() {
        dialogueManager.SetActiveDialogue(IngameDialogue.LEVEL_1_END);
    }

    public void PlayerDeath() {
        deathPanel.Animate();
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

}
