using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    
    //General variables
    private static Dictionary<string, LevelManager> managers = new Dictionary<string, LevelManager>();

    private string levelId;

    //Level stats
    private int fragments;

    public LevelManager(string levelId) {
        this.levelId = levelId;
        managers.Add(levelId, this);
    }

    public static void CreateNewManager(string id) {
        if(!managers.ContainsKey(id)) {
            LevelManager manager = new LevelManager(id);
        } else {
            Debug.LogWarning("There is already a manager active with the id " + id + ".");
        }
    }

    public static LevelManager GetManager(string id) {
        
        if(managers.ContainsKey(id)) {
            return managers[id];
        } else {
            return new LevelManager(id);
        }

    }

    public void AddFragment(int amount) {
        fragments += amount;
    }

}
