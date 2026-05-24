using System.Collections.Generic;
using UnityEngine;

public class EffectSounder : SoundPlayer
{
    [SerializeField] private float soundVariance;
    [SerializeField] private List<AudioClip> activeSounds;

    private int currentClip = 0;

    internal void PlayAudio(AudioClip clip)
    {
        audioSource.volume = settings.soundEffectVolumeSetting;

        audioSource.clip = activeSounds[currentClip];
        currentClip++;
        if(currentClip >= activeSounds.Count)
        {
            currentClip = 0;
        }

        audioSource.pitch = Random.Range(1 - soundVariance, 1 + soundVariance);
        audioSource.Play();
    }

    internal void StopAudio()
    {
        audioSource.Stop();
        audioSource.clip = null;
    }
}
