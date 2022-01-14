using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DeathPanel : MonoBehaviour {

    [SerializeField] private GameObject deathText;
    [SerializeField] private GameObject deathsubText;

    private Image overlayPanel;

    void Awake() {
        overlayPanel = gameObject.GetComponent<Image>();
        overlayPanel.color = new Color(0, 0, 0, 0);
        deathText.SetActive(false);
        deathsubText.SetActive(false);
    }

    public void Animate() {
        StartCoroutine(FadeOverlay());
    }

    private IEnumerator FadeOverlay() {

        for (float i = 0; i <= 1; i += Time.deltaTime) {
            overlayPanel.color = new Color(0, 0, 0, i);
            yield return null;
        }

        deathText.SetActive(true);
        deathsubText.SetActive(true);

    }

}
