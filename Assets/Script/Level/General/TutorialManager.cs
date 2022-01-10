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
            zones[0].SetActive(true);
            zones[1].SetActive(false);
        } else if(state == 1) {
            playerController.SetAllowRotation(true);
            playerController.SetAllowBrake(false);
            playerController.SetAllowBoost(false);
            playerController.SetFailRotation(true);
            zones[0].SetActive(false);
            zones[1].SetActive(true);
        } else if(state == 2) {
            playerController.SetAllowRotation(true);
            playerController.SetAllowBrake(false);
            playerController.SetAllowBoost(false);
            playerController.SetFailRotation(false);
            zones[0].SetActive(false);
            zones[1].SetActive(false);
        } else if(state == 3) {
            playerController.SetAllowRotation(true);
            playerController.SetAllowBrake(true);
            playerController.SetAllowBoost(true);
            playerController.SetFailRotation(false);
            zones[0].SetActive(false);
            zones[1].SetActive(false);
            zones[2].SetActive(false);
        }

    }

    public void SetState(int state) {
        this.state = state;
    
    }

    public int GetState() {
        return state;
    }

}
