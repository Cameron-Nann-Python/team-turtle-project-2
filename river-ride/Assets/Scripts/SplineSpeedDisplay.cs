using UnityEngine;
using TMPro;
using UnityEngine.Splines;

public class SplineSpeedDisplay : MonoBehaviour
{
    public TextMeshProUGUI speedText;
    public SplineAnimate splineAnimation;

    private void FixedUpdate()
    {
        if (splineAnimation.MaxSpeed < 1f || !splineAnimation.IsPlaying)
        {
            speedText.text = "0.00 m/s";
        }
        else
        {
            speedText.text = splineAnimation.MaxSpeed.ToString("F2") + " m/s";
        }
    }
}
