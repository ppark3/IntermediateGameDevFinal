using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySounds : MonoBehaviour
{
    public AudioClip[] sounds;
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
        if(whichOne < sounds.Length && aud.clip != sounds[whichOne])
        {
            aud.Stop();
            aud.clip = sounds[whichOne];
            aud.Play();
        }
        
    }
}
