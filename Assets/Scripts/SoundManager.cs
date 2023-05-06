using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject player;

    public AudioClip playerSound;
    public AudioClip javelinSound;
    public AudioClip crowdSound;

    public static SoundManager instance;
    AudioSource playerAudio;




    void Start()
    {
        instance = this;
        playerAudio = player.GetComponent<AudioSource>();
       

    }
    public void StartCrowdSound()
    {
        playerAudio.clip = crowdSound;
        playerAudio.Play();
    }
    public void StartWalkSound()
    {
        playerAudio.clip = playerSound;
        playerAudio.Play();
    }

    public void StopWalkSound()
    {
        playerAudio.Stop();
    }
    public void StartJavelinSound()
    {
        playerAudio.clip = javelinSound;
        playerAudio.Play();
    }



    // Update is called once per frame
    void Update()
    {

    }
}
