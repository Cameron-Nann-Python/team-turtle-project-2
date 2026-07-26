using UnityEngine;
using UnityEngine.Splines;
public class BoatStartStop : MonoBehaviour
{
    public SplineAnimate splineAnimation;
    public float startSpeed = 15f; // Speed at which the boat starts moving
    public bool boatMoving = false; // Whether the boat is moving automatically on awake

    public AudioSource engine;  
    public AudioSource engineStop;
    public void toggleBoat()
    {
        if (boatMoving) {
            stopBoat();
        } else {
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
}
