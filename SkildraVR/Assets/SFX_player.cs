using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFX_player : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip[] audioClips;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip(int arrayIndex){
        if (audioClips[arrayIndex] != null)
        {
            audioSource.clip = audioClips[arrayIndex];
            audioSource.Play();
        }
        else throw new System.Exception("Object: " + this.gameObject.name + "Audio clip is null");
        
    }

    public void StopPlaying(){
        audioSource.Stop();
    }
}
