using UnityEngine;
using TMPro;
using UnityEngine.Splines;

public class SplineSpeedDisplay : MonoBehaviour
{
    public TextMeshProUGUI speedText;
    public SplineAnimate splineAnimation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        speedText.text = splineAnimation.MaxSpeed.ToString("F2") + " m/s";
    }
}
