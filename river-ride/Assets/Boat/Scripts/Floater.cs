using UnityEngine;

public class Floater : MonoBehaviour
{
    // Buoyancy
    public float Power;
    public float Speed;
    public float Frequency;
    public float WaterLevel;

    public float Buoyancy;
    public float MaxBuoyancy;

    // Water Drag
    private float OriginalDrag;
    private float OriginalAngularDrag;
    private int isUnderWater;
    public float WaterDrag;
    public float WaterAngularDrag;

    // Boat
    private Rigidbody rb;
    public Transform[] FloatingPoints;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        OriginalAngularDrag = rb.angularDamping;
        OriginalDrag = rb.linearDamping;
    }

    // Use fixed for Rigidbody
    private void FixedUpdate()
    {
        ApplyBuoyancy();
    }

    private void ApplyBuoyancy()
    {
        isUnderWater = 0;
        // Update boat buoyancy based on floating point
        foreach (Transform point in FloatingPoints)
        {
            Vector3 position = point.position;
            float WaveHeight = CalculateWaveHeight(position.x, position.z);
            float submersionDepth = WaveHeight - position.y;

            // Raise object if submerged
            if (submersionDepth > 0)
            {
                isUnderWater++;
                float force = Mathf.Min(submersionDepth * Buoyancy, MaxBuoyancy);
                Vector3 buoyancyForce = Vector3.up * force;
                // Apply buoyancy force at position instead of boat center
                rb.AddForceAtPosition(buoyancyForce, position, ForceMode.Acceleration);
            }
        }

        // Apply water drag/reset drag
        if (isUnderWater > 0)
        {
            rb.linearDamping = WaterDrag;
            rb.angularDamping = WaterAngularDrag;
        }
        else
        {
            rb.linearDamping = OriginalDrag;
            rb.angularDamping = OriginalAngularDrag;
        }
    }

    // Determine waterlevel + height of waves (minimal for river)
    public float CalculateWaveHeight(float x, float z)
    {
        float wave = Power * Mathf.Sin(((x+z) * Frequency) + (Time.time * Speed));
        return wave + WaterLevel;
    }

}
