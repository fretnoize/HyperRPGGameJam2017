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
    //private Vector3 alwaysStartPos = new Vector3(0.0f, -100.0f, 0.0f);
    void Start ()
    {
        //transform.parent = parentTarget;
	}
	

	void Update ()
    {
        if (!lerpFinished)
            doLerp();
    }

    public void SetStart(Vector3 startPos, float startArea, float minTime, float maxTime, Transform parent)
    {
        lerpFinished = true;
        destination = transform.localPosition;
        transform.localPosition = new Vector3(
            startPos.x + Random.Range(-(startArea / 2), (startArea / 2)),
            startPos.y + Random.Range(-(startArea / 2), (startArea / 2)),
            startPos.z + Random.Range(-(startArea / 2), (startArea / 2)));
        lerpDuration = Random.Range(minTime, maxTime);
        
        startPosition = transform.localPosition;
        StartCoroutine(StartLerp());
        //transform.rotation = parent.localRotation;
        //parentTarget = parent;
    }

    IEnumerator StartLerp()
    {
        yield return new WaitForSeconds(0f);
        lerpStartTime = Time.time;
        lerpFinished = false;
    }

    private void doLerp()
    {
        float durationCount = lerpStartTime + lerpDuration;
        if (Time.time > durationCount)
        {
            durationCount = lerpDuration;
            lerpFinished = true;
        }
        float timePercent = (Time.time - lerpStartTime) / lerpDuration;
        float percent = MovementCurve.Evaluate(timePercent);
        Vector3 newPos = Vector3.LerpUnclamped(startPosition, destination, percent);
        transform.localPosition = newPos;
        if (lerpFinished)
            transform.localPosition = destination;
    }
}
