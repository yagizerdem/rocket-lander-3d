using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessParticleController : MonoBehaviour
{
    ParticleSystem successParticleSytem;
    GameObject rocket;
    void Start()
    {
        successParticleSytem = GetComponent<ParticleSystem>();
        successParticleSytem.playOnAwake = false;
        successParticleSytem.loop = false;
        rocket = GameObject.Find("Rocket_2");
    }
    private void Update()
    {
        transform.position = rocket.transform.position;
    }

    public void PlaySuccessParticleEffect()
    {
        successParticleSytem.Play();
    }
}
