using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;

    private void FixedUpdate()
    {
        // If floater completely underwater, raise
        float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);
        if (transform.position.y < waveHeight)
        {
            // Estimate how far down the floater is submerged
            // Buoyancy force should be the same no matter where floater is
            // completely submerged, so clamp value
            float displacementMultiplier = Mathf.Clamp01(-transform.position.y / depthBeforeSubmerged) * displacementAmount;

            // Raise the floater
            rigidBody.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), ForceMode.Acceleration);
        }
    }
}
