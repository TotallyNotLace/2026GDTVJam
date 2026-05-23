using UnityEngine;

public class Sounder : MonoBehaviour
{
    [SerializeField] internal AudioSource audioSource;
    [SerializeField] private float soundVariance;

    internal void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.pitch = Random.Range(1 - soundVariance, 1 + soundVariance);
        audioSource.Play();
    }

    internal void StopAudio()
    {
        audioSource.Stop();
        audioSource.clip = null;
    }
}
