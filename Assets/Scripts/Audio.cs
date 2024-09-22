using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource audioSource;

    public void PlayClip(AudioClip _clip)
    {
        audioSource.PlayOneShot(_clip);
    }
}
