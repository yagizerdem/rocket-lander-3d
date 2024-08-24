using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustSoundController : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip thrustSound;
    AudioClip hitSound;
    private bool musicFadeOutEnabled = false;
    [SerializeField] float musicFadeOutCoEfficient = 3f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        thrustSound = (AudioClip)Resources.Load("Audio/thrust");
        hitSound = (AudioClip)Resources.Load("Audio/hitSound");
        audioSource.clip = thrustSound;
        audioSource.playOnAwake = false;
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (RocketStates.instance.playThrustSound)
        {
            PlayThrustSound();
        }
        if (RocketStates.instance.playHitSound)
        {
            PlayHitSound();
        }
    }
    public void PlayerMusic()
    {
        musicFadeOutEnabled = false;
        audioSource.volume = 1f;
        audioSource.Play();
    }
    public void FadeOutMusic()
    {
        musicFadeOutEnabled = true;
    }
    public void UpdateVolume()
    {
        if (musicFadeOutEnabled)
        {
            if (audioSource.volume <= 0.1f)
            {
                audioSource.Stop();
                musicFadeOutEnabled = false;
            }
            else
            {
                float newVolume = audioSource.volume - (musicFadeOutCoEfficient * Time.deltaTime);  //change 0.01f to something else to adjust the rate of the volume dropping
                if (newVolume < 0f)
                {
                    newVolume = 0f;
                }
                audioSource.volume = newVolume;
            }
        }
    }
    public bool isKeyPressed()
    {
        return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
    }
    public void PlayThrustSound()
    {
        if (isKeyPressed() && !audioSource.isPlaying)
        {
            PlayerMusic();
        }

        if (!isKeyPressed() && audioSource.isPlaying)
        {
            FadeOutMusic();
        }
        UpdateVolume();
    }

    public void PlayHitSound()
    {
        if (audioSource.isPlaying) audioSource.Stop();
        audioSource.PlayOneShot(hitSound);
        RocketStates.instance.playHitSound = false;
    }
}
