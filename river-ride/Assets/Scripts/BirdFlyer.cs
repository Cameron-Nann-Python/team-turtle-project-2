using UnityEngine;

public class BirdFlyer : MonoBehaviour
{
    public float speed = 6f;
    public float bobHeight = 0.5f;
    public float bobSpeed = 2f;
    public float lifetime = 30f;

    private Vector3 direction;
    private bool directionSet = false;
    private float startY;
    private float bobTimer;

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
        directionSet = true;
    }

    void Start()
    {
        startY = transform.position.y;

        if (directionSet && direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
        else
        {
            direction = transform.forward;
        }

        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        bobTimer += Time.deltaTime * bobSpeed;
        Vector3 pos = transform.position;
        pos.y = startY + Mathf.Sin(bobTimer) * bobHeight;
        transform.position = pos;
    }
}
