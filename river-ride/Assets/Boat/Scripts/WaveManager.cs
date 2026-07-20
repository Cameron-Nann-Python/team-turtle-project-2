using UnityEngine;

public class WaveManager : MonoBehaviour
{
  public static WaveManager instance;

  // Simulate water movement
  public float amplitude = 0.5f;
  public float length = 0.5f;
  public float speed = 1.0f;
  public float offset = 0.0f;


  // Only need one instance of water movement
  private void Awake()
  {
    if (instance == null)
    {
        instance = this;
    }
    else if (instance != this)
    {
        Debug.Log("Instance already exists, destroy object.");
        Destroy(this);
    }
  }

  private void Update()
  {
    offset += Time.deltaTime * speed;
  }

  public float GetWaveHeight(float _x)
  {
    return amplitude * Mathf.Sin(_x / length + offset);
  }
}
