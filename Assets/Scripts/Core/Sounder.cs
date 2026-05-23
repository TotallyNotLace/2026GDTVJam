using UnityEngine;

public class Sounder : MonoBehaviour
{
    [SerializeField] internal AudioSource audioSource;

    internal void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    internal void StopAudio()
    {
        audioSource.Stop();
        audioSource.clip = null;
    }
}
