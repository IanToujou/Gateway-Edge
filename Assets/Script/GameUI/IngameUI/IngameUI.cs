using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour {
    
    [SerializeField] private GameObject dialoguePanel;

    void Awake() {
        dialoguePanel.SetActive(false);
    }

}
