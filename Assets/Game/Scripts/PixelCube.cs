using UnityEngine;

namespace Assets.Game.Scripts
{
    public class PixelCube : MonoBehaviour
    {
        public AnimationCurve MovementCurve;
        private Vector3 destination, startPosition;
        private float lerpDuration;

        private bool lerpFinished;
        private float lerpStartTime;
        private Transform parentTarget;
        void Start()
        {
            this.transform.parent = this.parentTarget;
        }


        void Update()
        {
            if (!this.lerpFinished)
                this.doLerp();
        }

        public void SetStart(Vector3 startPos, float startArea, float minTime, float maxTime, Transform parent)
        {
            this.destination = this.transform.localPosition;
            this.transform.position = new Vector3(
                startPos.x + Random.Range(-(startArea / 2), (startArea / 2)),
                startPos.y,
                startPos.z + Random.Range(-(startArea / 2), (startArea / 2)));
            this.lerpDuration = Random.Range(minTime, maxTime);
            this.lerpStartTime = Time.time;
            this.startPosition = this.transform.position;
            this.transform.rotation = parent.localRotation;
            this.parentTarget = parent;
        }

        private void doLerp()
        {
            var durationCount = Time.time - this.lerpDuration;
            if (durationCount > this.lerpDuration)
            {
                durationCount = this.lerpDuration;
                this.lerpFinished = true;
            }
            var timePercent = (Time.time - this.lerpStartTime) / this.lerpDuration;
            var percent = this.MovementCurve.Evaluate(timePercent);
            var newPos = Vector3.LerpUnclamped(this.startPosition, this.destination, percent);
            this.transform.localPosition = newPos;
        }
    }
}
