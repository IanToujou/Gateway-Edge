using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicUI : MonoBehaviour {
    
    [SerializeField] private List<AudioClip> clipList = new List<AudioClip>();

    private AudioSource audioSource;
    private int songId;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable() {
        foreach(Button all in GetComponentsInChildren<Button>()) {
            all.GetComponentInChildren<Text>().color = Color.white;
        }
    }

    void Update() {
        GetComponentsInChildren<Button>()[songId+1].GetComponentInChildren<Text>().color = Color.cyan;
    }

    public void ButtonPressPlay(int songId) {

        foreach(Button all in GetComponentsInChildren<Button>()) {
            all.GetComponentInChildren<Text>().color = Color.white;
        }

        this.songId = songId;
        GameObject.Find("PlayerCamera").GetComponent<AudioSource>().mute = true;
        audioSource.loop = false;
        audioSource.clip = clipList[songId];
        audioSource.Play();
    }

    public void ButtonPressBack() {
        this.songId = 0;
        audioSource.Stop();
        GameObject.Find("PlayerCamera").GetComponent<AudioSource>().mute = false;
        GameObject.Find("PlayerCamera").GetComponent<AudioSource>().time = 0;
        UISoundManager.GetInstance().PlayAudioClip(UISoundClipList.SFX_UI_CLICK);
        MenuUIManager.SetActiveCanvas(MenuUILayout.MENU);
    }

}
