using UnityEngine;
using UnityEngine.Splines;
public class BoatStartStop : MonoBehaviour
{
    public SplineAnimate splineAnimation;
    public float startSpeed = 15f; // Speed at which the boat starts moving
    public bool boatMoving = false; // Whether the boat is moving automatically on awake

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
        boatMoving = true;
        splineAnimation.Play();
        splineAnimation.MaxSpeed = startSpeed;
    }
    void stopBoat()
    {
        boatMoving = false;
        splineAnimation.Pause();
        splineAnimation.MaxSpeed = 0f;
    }
}
