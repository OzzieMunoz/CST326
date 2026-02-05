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
        Vector3 offset = new Vector3(magnitude, 0f, magnitude);

        cameraTransform.localPosition = originalPos + offset;
        yield return new WaitForSeconds(duration);
        cameraTransform.localPosition = originalPos;
    }
}