using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {
    
    [SerializeField] private List<GameObject> zones = new List<GameObject>();

    private LevelManager levelManager;
    private PlayerController playerController;
    private int state;

    void Start() {
        state = 0;
        levelManager = LevelManager.GetCurrentManager();
        playerController = levelManager.GetPlayer().GetComponent<PlayerController>();
    }

    void Update() {

        if(state == 0) {
            playerController.SetAllowRotation(false);
            playerController.SetAllowBrake(false);
            playerController.SetAllowBoost(false);
            playerController.SetFailRotation(true);
            SetActiveZone(0);
        } else if(state == 1) {
            playerController.SetAllowRotation(true);
            playerController.SetAllowBrake(false);
            playerController.SetAllowBoost(false);
            playerController.SetFailRotation(true);
            SetActiveZone(1);
        } else if(state == 2) {
            playerController.SetAllowRotation(true);
            playerController.SetAllowBrake(false);
            playerController.SetAllowBoost(false);
            playerController.SetFailRotation(false);
            SetActiveZone(2);
        } else if(state == 3) {
            playerController.SetAllowRotation(true);
            playerController.SetAllowBrake(true);
            playerController.SetAllowBoost(true);
            playerController.SetFailRotation(false);
            SetActiveZone(3);
        }

    }

    public void SetState(int state) {
        this.state = state;
    
    }

    public int GetState() {
        return state;
    }

    public void SetActiveZone(int zoneNumber) {
        for(int i = 0; i < zones.Count; i++) {
            if(i != zoneNumber) {
                zones[i].SetActive(false);
            } else {
                zones[i].SetActive(true);
            }
        }
    }

    public void DeactiveAllZones() {
        foreach(GameObject all in zones) {
            all.SetActive(false);
        }
    }

}
