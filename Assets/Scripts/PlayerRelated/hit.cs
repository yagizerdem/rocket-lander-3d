using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hit : MonoBehaviour
{
    ThrustSoundController soundController;
    public GameObject levelRelatedScriptPlaceHodler;
    LevelController levelController;
    GameObject explosionParticleSystemGameObject;
    ExplosionParticleController explosionParticleController;
    GameObject successParticleSystemGameObject;
    SuccessParticleController successParticleController;
    private void Start()
    {
        soundController = GetComponent<ThrustSoundController>();    
        levelController = levelRelatedScriptPlaceHodler.GetComponent<LevelController>();

        explosionParticleSystemGameObject = GameObject.Find("ExplosionParticleSytem");
        explosionParticleController = explosionParticleSystemGameObject.GetComponent<ExplosionParticleController>();
       
        successParticleSystemGameObject = GameObject.Find("SuccessParticleSystem");
        successParticleController = successParticleSystemGameObject.GetComponent<SuccessParticleController>();
    }
    void OnCollisionEnter(Collision collision)
    {
        // Get the GameObject that this object collided with
        GameObject collidedObject = collision.gameObject;

        // Get the tag of the collided GameObject
        string collidedObjectTag = collidedObject.tag;
        if(collidedObjectTag == "obstacle")
        {
            if (RocketStates.instance.isFinished) return;

            RocketStates.instance.playThrustSound = false;
            RocketStates.instance.playHitSound = RocketStates.instance.isHit == false ? true : false; // if rocket hit sound played , do not play second time
            if (!RocketStates.instance.isHit)
            {
                explosionParticleController.PlayExplosionParticleEffect();
                Invoke(nameof(ReloadScene), 3f);
            }
            RocketStates.instance.isHit = true;

        }
        else if(collidedObjectTag == "landingPaddle")
        {
            if (RocketStates.instance.isHit || RocketStates.instance.isFinished) return;
            successParticleController.PlaySuccessParticleEffect();
            RocketStates.instance.isFinished = true;
            Invoke(nameof(LoadNextLevel), 3f);

        }
    }

    void ReloadScene()
    {
        levelController.ReloadCurrentScene();
    }
    
    void LoadNextLevel()
    {
        levelController.LoadMainMenu();
    }
}
