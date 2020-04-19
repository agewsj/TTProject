using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingleTon<SoundManager>
{
    public List<AudioClip> bgSoundList = new List<AudioClip>();
    public AudioSource bgAudioSource;

    public AudioClip attackSound;
    public AudioSource normalAudioSource;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void PlayBGSound(int _bgNum)
    {
        bgAudioSource.clip = bgSoundList[_bgNum];
        bgAudioSource.loop = true;
        bgAudioSource.time = 0;
        bgAudioSource.Play();
    }

    public void PlayAttackSound()
    {
        normalAudioSource.clip = attackSound;
        normalAudioSource.loop = false;
        normalAudioSource.time = 0;
        normalAudioSource.Play();
    }

    public void StopAttackSound()
    {
        normalAudioSource.Stop();
    }
}
