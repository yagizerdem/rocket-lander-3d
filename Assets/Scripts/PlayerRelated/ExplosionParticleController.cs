using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticleController : MonoBehaviour
{
    ParticleSystem explosionParticleSytem;
    GameObject rocket;
    void Start()
    {
        explosionParticleSytem = GetComponent<ParticleSystem>();
        explosionParticleSytem.playOnAwake = false;
        explosionParticleSytem.loop = false;
        rocket = GameObject.Find("Rocket_2");
    }
    private void Update()
    {
        transform.position = rocket.transform.position;
    }

    public void PlayExplosionParticleEffect()
    {
        explosionParticleSytem.Play();
    }
}
