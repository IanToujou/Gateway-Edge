using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneUI : MonoBehaviour {

    [SerializeField] private int zoneNumber;
    [SerializeField] private List<GameObject> levelButtons = new List<GameObject>();



    void Start() {

        SaveManager saveManager = SaveManager.GetInstance();

        if(zoneNumber == 1) {

            

        }

    }

}
