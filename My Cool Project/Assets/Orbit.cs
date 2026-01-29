using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float orbitSpeed = 10f;

    void Update()
    {
        transform.Rotate(Vector3.up, orbitSpeed * Time.deltaTime, Space.World);
    }
}