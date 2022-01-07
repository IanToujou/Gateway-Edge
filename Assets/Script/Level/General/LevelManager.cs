using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    [SerializeField] private string levelId;

    //General variables
    private static LevelManager instance;

    //Level stats
    private int fragments;

    //Interactive elements
    private bool teleporterActive;

    void Awake() {
        instance = this;
        fragments = 0;
        teleporterActive = true;
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

}
