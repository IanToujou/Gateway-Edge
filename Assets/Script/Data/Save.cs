using System.Collections.Generic;

[System.Serializable]
public class Save {
    
    public int fragments = 0;
    public List<int> completedLevels = new List<int>();
    public List<int> collectedProtocols = new List<int>();

    public bool IsLevelCompleted(int levelId) {
        return completedLevels.Contains(levelId);
    }

    public void SetLevelCompleted(int levelId) {
        if(!IsLevelCompleted(levelId)) completedLevels.Add(levelId);
    }

    public bool IsProtocolCollected(int levelId) {
        return collectedProtocols.Contains(levelId);
    }

    public void SetProtocolCollected(int levelId) {
        if(!IsProtocolCollected(levelId)) collectedProtocols.Add(levelId);
    }

}