using UnityEngine;
using System.Collections;

public class Swing2 : MonoBehaviour
{
    [Header("Swing Settings")]
    public float swingAngle = 90f;          // How far the sword swings
    public float swingDuration = 0.3f;      // How long the swing takes
    public float returnDuration = 0.2f;     // How long to return to start

    private Quaternion initialRotation;
    private bool isSwinging = false;

    void Start()
    {
        // Remember the sword's starting rotation
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        // Left click to swing (only if not already swinging)
        if (Input.GetMouseButtonDown(0) && !isSwinging)
        {
            StartCoroutine(PerformSwing());
        }
    }

    System.Collections.IEnumerator PerformSwing()
    {
        isSwinging = true;

        // SWING FORWARD (Downward chop)
        float timer = 0f;
        Quaternion startRot = transform.localRotation;
        Quaternion endRot = initialRotation * Quaternion.Euler(swingAngle, 0, 0);

        while (timer < swingDuration)
        {
            timer += Time.deltaTime;
            float progress = timer / swingDuration;
            transform.localRotation = Quaternion.Lerp(startRot, endRot, progress);
            yield return null;
        }

        // RETURN TO START
        timer = 0f;
        while (timer < returnDuration)
        {
            timer += Time.deltaTime;
            float progress = timer / returnDuration;
            transform.localRotation = Quaternion.Lerp(endRot, initialRotation, progress);
            yield return null;
        }

        // Make sure we're exactly back at start
        transform.localRotation = initialRotation;
        isSwinging = false;
    }
}