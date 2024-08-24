using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    ParticleSystem particleSystemMainThrust , particleSystemLeftThrust , particleSystemRightThrust;
    void Start()
    {
        particleSystemMainThrust = transform.Find("ParticleSystemMainThrust").gameObject.GetComponent<ParticleSystem>();
        particleSystemMainThrust.loop = true;
        particleSystemMainThrust.playOnAwake = false;

        particleSystemLeftThrust = transform.Find("ParticleSystemLeftThrust").gameObject.GetComponent<ParticleSystem>();
        particleSystemLeftThrust.loop = true;
        particleSystemLeftThrust.playOnAwake = false;

        particleSystemRightThrust = transform.Find("ParticleSystemRightThrust").gameObject.GetComponent<ParticleSystem>();
        particleSystemRightThrust.loop = true;
        particleSystemRightThrust.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!RocketStates.instance.isHit)
        {
            MainThrustController();
            LeftThrustController();
            RightThrustController();
        }
        else
        {
            if(particleSystemLeftThrust.isPlaying) particleSystemLeftThrust.Stop();
            if (particleSystemRightThrust.isPlaying)  particleSystemRightThrust.Stop();
            if (particleSystemMainThrust.isPlaying)  particleSystemMainThrust.Stop();
        }

    }
    void MainThrustController()
    {
        if (Input.GetAxis("Vertical") >= Mathf.Epsilon)
        {
            if (!particleSystemMainThrust.isPlaying)
            {
                particleSystemMainThrust.Play();
            }
        }
        else
        {
            if (particleSystemMainThrust.isPlaying)
            {
                particleSystemMainThrust.Stop();
            }
        }
    }
    void LeftThrustController()
    {
        if (Input.GetAxis("Horizontal") >= Mathf.Epsilon)
        {
            if (!particleSystemLeftThrust.isPlaying)
            {
                particleSystemLeftThrust.Play();
            }
        }
        else
        {
            if (particleSystemLeftThrust.isPlaying)
            {
                particleSystemLeftThrust.Stop();
            }
        }
    }
    void RightThrustController()
    {
        if (Input.GetAxis("Horizontal") <= -Mathf.Epsilon)
        {
            if (!particleSystemRightThrust.isPlaying)
            {
                particleSystemRightThrust.Play();
            }
        }
        else
        {
            if (particleSystemRightThrust.isPlaying)
            {
                particleSystemRightThrust.Stop();
            }
        }
    }
}
