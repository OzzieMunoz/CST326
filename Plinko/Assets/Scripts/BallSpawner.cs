using UnityEngine;
using UnityEngine.InputSystem;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;

    [Header("Spawn settings")]
    public float spawnY = 1.0f;     // height above pegs
 
    void Update()
    {
        // New Input System version of Space key
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        if (ballPrefab == null) return;

        // X stays fixed (depth)
        float x = transform.position.x;

        // Y is vertical
        float y = spawnY;

        // Z is left/right and random
        float z = Random.Range(0f, 2f);

        Vector3 spawnPos = new Vector3(x, y, z);

        GameObject ball = Instantiate(ballPrefab, spawnPos, Quaternion.identity);

        // Lock X so the ball never drifts forward/back
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.constraints |= RigidbodyConstraints.FreezePositionX;
        }
    }
}