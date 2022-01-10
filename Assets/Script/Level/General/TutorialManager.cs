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
            playerController.SetTeleportInsteadDeath(true);
        } else if(state == 1) {
            playerController.SetAllowRotation(true);
        } else if(state == 2) {
            playerController.SetFailRotation(false);
            playerController.SetTeleportInsteadDeath(false);
        } else if(state == 5) {
            playerController.SetAllowBrake(true);
            playerController.SetAllowBoost(true);
        }

        SetActiveZone(state);

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
