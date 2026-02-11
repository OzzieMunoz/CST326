using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform;

    void Awake()
    {
        if (cameraTransform == null)
            cameraTransform = transform;
    }

    public void Shake(float duration, float magnitude)
    {
        StopAllCoroutines();
        StartCoroutine(DoShake(duration, magnitude));
    }

    IEnumerator DoShake(float duration, float magnitude)
    {
        Vector3 originalPos = cameraTransform.localPosition;

        float seed = Random.Range(0f, 1000f);

        float elapsed = 0f;
        while (elapsed < duration)
        {
            float t = seed + elapsed * 25f; 
            float n1 = Mathf.PerlinNoise(t, 0f);
            float n2 = Mathf.PerlinNoise(0f, t);

            float x = (n1 * 2f - 1f) * magnitude;
            float y = (n2 * 2f - 1f) * magnitude;

            cameraTransform.localPosition = originalPos + new Vector3(x, 0f, y);

            elapsed += Time.deltaTime;
            yield return null;
        }

        cameraTransform.localPosition = originalPos;
    }
}