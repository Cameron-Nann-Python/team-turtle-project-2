using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject[] birdPrefabs;
    public Transform startPoint;
    public Transform endPoint;
    public float minSpawnInterval = 4f;
    public float maxSpawnInterval = 10f;
    public float minSpeed = 4f;
    public float maxSpeed = 8f;
    public float directionSpreadDegrees = 20f;

    void Start()
    {
        ScheduleNextSpawn();
    }

    void ScheduleNextSpawn()
    {
        float delay = Random.Range(minSpawnInterval, maxSpawnInterval);
        Invoke(nameof(SpawnBird), delay);
    }

    void SpawnBird()
    {
        if (birdPrefabs.Length > 0 && startPoint != null && endPoint != null)
        {
            GameObject prefab = birdPrefabs[Random.Range(0, birdPrefabs.Length)];
            GameObject bird = Instantiate(prefab, startPoint.position, Quaternion.identity);

            BirdFlyer flyer = bird.GetComponent<BirdFlyer>();
            if (flyer == null)
            {
                flyer = bird.AddComponent<BirdFlyer>();
            }

            Vector3 baseDirection = endPoint.position - startPoint.position;
            float yaw = Random.Range(-directionSpreadDegrees, directionSpreadDegrees);
            float pitch = Random.Range(-directionSpreadDegrees, directionSpreadDegrees);
            Quaternion spread = Quaternion.Euler(pitch, yaw, 0f);

            flyer.SetDirection(spread * baseDirection);
            flyer.speed = Random.Range(minSpeed, maxSpeed);
        }

        ScheduleNextSpawn();
    }
}
