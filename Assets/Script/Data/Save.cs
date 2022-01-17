using System.Collections.Generic;

[System.Serializable]
public class Save {
    
    private int fragments;
    private List<int> completedLevels;
    private List<int> collectedProtocols;

    public Save() {
        fragments = 0;
        completedLevels = new List<int>();
        collectedProtocols = new List<int>();
    }

    public int GetFragments() {
        return fragments;
    }

    public void AddFragments(int amount) {
        fragments += amount;
    }

    public void RemoveFragments(int amount) {
        fragments -= amount;
    }

    public void SetFragments(int amount) {
        fragments = amount;
    }

    public List<int> GetCompletedLevels() {
        return completedLevels;
    }

    public bool IsLevelCompleted(int levelId) {
        return completedLevels.Contains(levelId);
    }

    public void SetLevelCompleted(int levelId) {
        if(!IsLevelCompleted(levelId)) completedLevels.Add(levelId);
    }

    public List<int> GetCollectedProtocols() {
        return collectedProtocols;
    }

    public bool IsProtocolCollected(int levelId) {
        return collectedProtocols.Contains(levelId);
    }

    public void SetProtocolCollected(int levelId) {
        if(!IsProtocolCollected(levelId)) collectedProtocols.Add(levelId);
    }

}