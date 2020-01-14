using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sSingleton { get { return _sSingleton; } }
    static SoundManager _sSingleton;

    public AudioSource backgroundSource;
    public AudioSource efxSource;
    public AudioSource distanceSource;

    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;

    void Awake() {
        if (_sSingleton != null && _sSingleton != this) Destroy(this.gameObject);
        else _sSingleton = this;

        DontDestroyOnLoad(this.gameObject);
    }

    //サウンド1個用
    public void PlaySingle(AudioClip clip) {
        efxSource.clip = clip;
        efxSource.Play();
    }

    //サウンド複数用
    public void RandomizeSfx(params AudioClip[] clips) {
        int randIndex = Random.Range(0, clips.Length);
        float randPitch = Random.Range(lowPitchRange, highPitchRange);
        efxSource.pitch = randPitch;
        efxSource.clip = clips[randIndex];
        efxSource.Play();
    }
}
