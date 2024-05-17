using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    AudioSource bgm;
    
    void Start() {
        bgm = this.GetComponent<AudioSource>();
    }

    void Update() {

    }

    public void ChangeBGM(AudioClip music) {
        if (bgm.clip.name == music.name) {
            return;
        }

        bgm.Stop();
        bgm.clip = music;
        bgm.Play();
    }
}