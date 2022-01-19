using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundManager : MonoBehaviour {
    
    private static UISoundManager instance;

    [SerializeField] List<AudioClip> audioClips = new List<AudioClip>();

    private int audioClipId;
    private AudioSource audioSource;

    void Awake() {
        instance = this;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayAudioClip(int audioClipId, bool loop) {
        this.audioClipId = audioClipId;
        audioSource.clip = audioClips[audioClipId];
        audioSource.loop = loop;
        audioSource.Play();
    }

    public void PlayAudioClip(int audioClipId) {
        this.audioClipId = audioClipId;
        audioSource.clip = audioClips[audioClipId];
        audioSource.loop = false;
        audioSource.Play();
    }

    public AudioSource GetAudioSource() {
        return audioSource;
    }

    public int GetAudioClipID() {
        return audioClipId;
    }

    public static UISoundManager GetInstance() {
        return instance;
    }

}
