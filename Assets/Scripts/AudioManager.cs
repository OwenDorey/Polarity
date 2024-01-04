using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource deathSound;
    public AudioSource coinCollect;
    public AudioSource woosh;

    public void OnDeath()
    {
        deathSound.Play();
    }

    public void OnWin()
    {
        coinCollect.Play();
    }

    public void OnFlip()
    {
        woosh.Play();
    }
}
