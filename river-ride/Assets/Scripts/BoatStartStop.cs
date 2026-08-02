using UnityEngine;
using UnityEngine.Splines;
public class BoatStartStop : MonoBehaviour
{
    public SplineAnimate splineAnimation;
    public float startSpeed = 15f; // Speed at which the boat starts moving
    public bool boatMoving = false; // Whether the boat is moving automatically on awake

    public AudioSource engine;  
    public AudioSource engineStop;

    bool movingBeforePause = false;
    bool paused = false;
    public void toggleBoat()
    {
        if (!paused)
        {
            if (boatMoving)
            {
                stopBoat();
            }
            else
            {
                startBoat();
                movingBeforePause = true;
            }
        }
    }
    public void forceStop()
    {
        if (boatMoving)
        {
            movingBeforePause = true;
            stopBoat();
            paused = true;
        }
    }
    public void forceStart()
    {
        paused = false;
        if (!boatMoving && movingBeforePause)
        {
            startBoat();
        }
    }
    void startBoat()
    {
        engine.Play();
        boatMoving = true;
        splineAnimation.Play();
        splineAnimation.MaxSpeed = startSpeed;
    }
    void stopBoat()
    {
        engine.Stop();
        engineStop.Play();
        boatMoving = false;
        splineAnimation.Pause();
        splineAnimation.MaxSpeed = 0f;
    }

    public void slowSpeed(bool on)
    {
        if (on) {
            startSpeed = 10f;
            splineAnimation.MaxSpeed = startSpeed;
        }
    }
    public void medSpeed(bool on)
    {
        if (on) {
            startSpeed = 15f;
            splineAnimation.MaxSpeed = startSpeed;
        }
    }
    public void fastSpeed(bool on)
    {
        if (on) {
            startSpeed = 20f;
            splineAnimation.MaxSpeed = startSpeed;
        }
    }
}
