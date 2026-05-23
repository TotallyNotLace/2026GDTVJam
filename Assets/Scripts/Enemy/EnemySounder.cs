using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.AI;


public class EnemySounder : Sounder
{
    [SerializeField] private EnemyObject stats;
    [SerializeField] private List<AudioClip> activeSounds;

    private bool isPlaying = false;

    private int currentActiveSound = 0;

    public void StartActiveSounds()
    {
        if(isPlaying) return;
        StartCoroutine(ActiveSoundCycle());
    }

    public void StopActiveSounds()
    {
        isPlaying = false;
        currentActiveSound = 0;
        StopAudio();
    }

    private IEnumerator ActiveSoundCycle()
    {
        isPlaying = true;
        while(isPlaying)
        {
            PlayAudio(activeSounds[currentActiveSound]);

            currentActiveSound++;

            if(currentActiveSound >= activeSounds.Count)
            {
                currentActiveSound = 0;
            }


            yield return new WaitForSeconds(stats.soundDelay);
        }

        

    }
}
