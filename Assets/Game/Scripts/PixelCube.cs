using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelCube : MonoBehaviour
{
    public AnimationCurve MovementCurve;
    private Vector3 destination, startPosition;
    private float lerpDuration;

    private bool lerpFinished;
    private float lerpStartTime;
    private Transform parentTarget;
	void Start ()
    {
        transform.parent = parentTarget;
	}
	

	void Update ()
    {
        if (!lerpFinished)
            doLerp();
	}

    public void SetStart(Vector3 startPos, float startArea, float minTime, float maxTime, Transform parent)
    {
        destination = transform.localPosition;
        transform.position = new Vector3(
            startPos.x + Random.Range(-(startArea / 2), (startArea / 2)),
            startPos.y,
            startPos.z + Random.Range(-(startArea / 2), (startArea / 2)));
        lerpDuration = Random.Range(minTime, maxTime);
        lerpStartTime = Time.time;
        startPosition = transform.position;
        transform.rotation = parent.localRotation;
        parentTarget = parent;
    }

    private void doLerp()
    {
        float durationCount = Time.time - lerpDuration;
        if (durationCount > lerpDuration)
        {
            durationCount = lerpDuration;
            lerpFinished = true;
        }
        float timePercent = (Time.time - lerpStartTime) / lerpDuration;
        float percent = MovementCurve.Evaluate(timePercent);
        Vector3 newPos = Vector3.LerpUnclamped(startPosition, destination, percent);
        transform.localPosition = newPos;
    }
}
