using UnityEngine;

public class Sounder : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
        audioSource.clip = null;
    }
}
