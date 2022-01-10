using UnityEngine;

public class TutorialManager : MonoBehaviour {
    
    private LevelManager levelManager;
    private int state;

    void Start() {
        state = 0;
        levelManager = LevelManager.GetCurrentManager();
    }

    

}
