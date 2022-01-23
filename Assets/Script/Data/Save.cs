using System.Collections.Generic;

[System.Serializable]
public class Save {

    private int fragments;
    private List<int> completedLevels;
    private List<int> collectedProtocols;
    private Dictionary<int, float> completionTimes;

    public Save() {
        fragments = 0;
        completedLevels = new List<int>();
        collectedProtocols = new List<int>();
        completionTimes = new Dictionary<int, float>();
    }

    public bool IsSaveActive() {
        return completedLevels.Count > 0;
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

    public float GetCompletionTime(int levelId) {
        if(completionTimes.ContainsKey(levelId))
        return completionTimes[levelId];
        else return 0f;
    }

    public void SetCompletionTime(int levelId, float completionTime) {
        if(completionTimes.ContainsKey(levelId)) completionTimes.Remove(levelId);
        completionTimes.Add(levelId, completionTime);
    }

    public Dictionary<int, float> GetCompletionTimes() {
        return completionTimes;
    }

    public void GetCompletionTimes(Dictionary<int, float> completionTimes) {
        this.completionTimes = completionTimes;
    }

}