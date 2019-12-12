using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundEffect : MonoBehaviour
{
    public AudioClip[] sfx;
    AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(int whichOne)
    {
        if(whichOne < sfx.Length)
        {
            aud.Stop();
            aud.clip = sfx[whichOne];
            aud.Play();
        }
        else
        {
            Debug.Log("going out of bounds for the sfx!!!");
        }
        
    }
}
