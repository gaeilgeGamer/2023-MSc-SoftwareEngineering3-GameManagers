using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagers{
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; 

    public AudioClip[] soundEffects;
    private AudioSource audioPlay;

    private void Awake(){
        if(Instance == null)
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        audioPlay = GetComponent<AudioSource>();
    }

    public void PlaySoundEffect(string clipName)
    {
        AudioClip clip = FindClipByName(clipName);
        if(clip != null)
        {
            audioPlay.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("Sound Effect not found: " + clipName);
        }
    }

    private AudioClip FindClipByName(string clipName)
    {
        foreach(AudioClip clip in soundEffects)
        {
            if (clip.name.Equals(clipName))
            {
                return clip;
            }
        }
        return null;
    }
}
}