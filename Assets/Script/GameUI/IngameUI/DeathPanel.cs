using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathPanel : MonoBehaviour {

    [SerializeField] private List<GameObject> textList = new List<GameObject>();

    private Image overlayPanel;

    void Awake() {
        overlayPanel = gameObject.GetComponent<Image>();
        overlayPanel.color = new Color(0, 0, 0, 0);
        SetTextActive(false);
    }

    public void Animate() {
        StartCoroutine(FadeOverlay());
    }

    private IEnumerator FadeOverlay() {

        for (float i = 0; i <= 1; i += Time.deltaTime) {
            overlayPanel.color = new Color(0, 0, 0, i);
            yield return null;
        }

        SetTextActive(true);

    }

    private void SetTextActive(bool active) {
        foreach(GameObject current in textList) {
            current.SetActive(active);
        }
    }

}
