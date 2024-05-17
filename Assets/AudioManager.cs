using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour

{
    public AudioSource musicsource;
    public AudioSource SFXsource;
    [Header("---------------------")]
    public AudioClip themebg;
    public AudioClip punch1;
    public AudioClip punch2;
    public AudioClip kick1;
    public AudioClip kick2;
    public AudioClip collectcoin;
    public AudioClip enemygethurt;
    public AudioClip maingethurt;
    public AudioClip shotgun;
    //tart is called before the first frame update
    void Start()
    {
        musicsource.clip = themebg;
        musicsource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);
    }
}
