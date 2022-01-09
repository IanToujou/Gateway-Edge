using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    [SerializeField] private string levelId;
    [SerializeField] private Text fragmentText;

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

    void Update() {
        fragmentText.text = fragments.ToString();
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
        player.GetComponentInChildren<TrailRenderer>().gameObject.SetActive(false);
    }

    public bool IsTeleporterActive() {
        return teleporterActive;
    }

}
