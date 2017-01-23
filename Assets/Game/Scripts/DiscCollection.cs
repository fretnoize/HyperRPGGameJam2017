using UnityEngine;

namespace Assets.Game.Scripts
{
    using System;

    public class DiscCollection : MonoBehaviour
    {
        private bool animating = false;

        private float lerpLength = 2f;
        private Vector3 startScale;

        public ObjectManager objectManager;

        private float startTime;

        private bool ripObject = false;

        // Use this for initialization
        void Start()
        {
            this.startScale = this.transform.localScale;
        }

        void Update()
        {
            if (this.animating && UiController.optionsMenu && UiController.mainMenu)
            {
                this.transform.localScale = Vector3.Lerp(
                    this.startScale,
                    this.startScale * 2,
                    (Time.time - this.startTime) / this.lerpLength);

                if (Time.time >= this.startTime + this.lerpLength && !this.ripObject)
                {
                    this.ripObject = true;
                    this.objectManager.removeDisc(this);
                }
            }
        }

        void OnMouseDown()
        {
            if (!this.animating && UiController.optionsMenu && UiController.mainMenu)
            {
                this.startTime = Time.time;
                this.animating = true;
            }
        }
    }
}
