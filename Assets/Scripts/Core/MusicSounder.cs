using UnityEngine;

public class MusicSounder : SoundPlayer
{
    [SerializeField] private AudioClip musicClip;

    public void PlayMusic()
    {
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.volume = settings.musicVolumeSetting;
        audioSource.Play();
    }
}
