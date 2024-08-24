using UnityEngine;

public class RocketStates :MonoBehaviour
{
    public static RocketStates instance;
    public bool isHit;
    public bool playHitSound;
    public bool playThrustSound;
    public bool isFinished;
    private void Awake()
    {
        RocketStates.instance = this;
        instance.isHit = false;
        instance.playHitSound = false;
        instance.playThrustSound = true;
        isFinished = false;
    }
}
