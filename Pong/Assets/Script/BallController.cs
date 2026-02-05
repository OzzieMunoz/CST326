using UnityEngine;

public class BallController : MonoBehaviour
{
    public float startSpeed = 10f;
    public float speedIncrease = 1f;
    public float hitStrength = 0.9f;

    public CameraShake cameraShake;

    private Rigidbody rb;
    private float currentSpeed;

    private bool lastScoredOnRight = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Application.targetFrameRate = 60;
        Serve();
    }
    
    void Serve()
    {
        currentSpeed = startSpeed;

        transform.position = Vector3.zero;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        
        float xDir = lastScoredOnRight ? 1f : -1f;
        
        float zDir = Random.Range(-0.25f, 0.25f);

        Vector3 dir = new Vector3(xDir, 0f, zDir).normalized;
        rb.linearVelocity = dir * currentSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Paddle"))
            return;

        cameraShake.Shake(0.12f, 0.10f);
        currentSpeed += speedIncrease; 
        
        float xDir = 1f;
        if (collision.transform.position.x > 0f)
            xDir = -1f;
        
        float ballZ = transform.position.z;
        float paddleZ = collision.transform.position.z;

        float zDiff = ballZ - paddleZ;
        
        float zDir = Mathf.Clamp(zDiff * hitStrength, -1f, 1f);
        
        Vector3 dir = new Vector3(xDir, 0f, zDir).normalized;
        rb.linearVelocity = dir * currentSpeed;
    }

    public void ResetRound(bool scoredOnRight)
    {
        lastScoredOnRight = scoredOnRight;
        Serve();
    }
}
