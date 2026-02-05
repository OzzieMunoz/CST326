using UnityEngine;
using UnityEngine.InputSystem;

public class DemoPaddle : MonoBehaviour
{
    public float paddleSpeed = 10f;
    public float minZ = -4.2f;
    public float maxZ = 4.2f;

    public Key upKey = Key.UpArrow;
    public Key downKey = Key.DownArrow;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var kb = Keyboard.current;
        float dir = 0f; 

        if (kb[upKey].isPressed) dir += 1f;
        if (kb[downKey].isPressed) dir -= 1f;

        Vector3 pos = rb.position;
        pos += new Vector3(0f, 0f, dir * paddleSpeed) * Time.fixedDeltaTime;
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        rb.MovePosition(pos);
    }
}