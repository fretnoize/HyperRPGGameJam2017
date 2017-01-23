using UnityEngine;

namespace Assets.Game.Scripts
{
    public class TabletController : MonoBehaviour
    {
        public Transform tabletOn;
        public Transform tabletOff;

        private bool raiseTablet;
        private bool lowerTablet;

        private bool tabletIsUp = false;

        private Vector3 startPosition;
        private readonly Vector3 onScreenPosition = new Vector3(0, -2, 185);

        private float tabletMovementSpeed = 15f;

        private bool lockTabletLowering = false;

        private float startLerpTime;

        private Vector3 triggeredPosition;

        private float movementDistance;

        // Use this for initialization
        void Start()
        {
            this.startPosition = this.transform.localPosition;
            this.tabletOn.GetComponent<Renderer>().enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (this.raiseTablet)
            {
                var distCovered = (Time.time - this.startLerpTime) * this.tabletMovementSpeed;
                var fracJourney = distCovered / this.movementDistance;
                this.transform.localPosition = Vector3.Lerp(
                    this.triggeredPosition,
                    this.onScreenPosition,
                    fracJourney);

                if (this.transform.localPosition == this.onScreenPosition)
                {
                    this.raiseTablet = false;
                    this.TurnTabletOn();
                    this.tabletIsUp = true;
                }
            }
            else if (this.lowerTablet)
            {
                var distCovered = (Time.time - this.startLerpTime) * this.tabletMovementSpeed;
                var fracJourney = distCovered / this.movementDistance;
                this.transform.localPosition = Vector3.Lerp(this.triggeredPosition, this.startPosition, fracJourney);
                if (this.transform.localPosition == this.startPosition)
                {
                    this.lowerTablet = false;
                    this.tabletIsUp = false;
                }
            }

            if (!UiController.optionsMenu || !UiController.mainMenu)
            {
                return;
            }

            if (Input.GetAxis("Vertical") < 0 && !this.raiseTablet && !this.lowerTablet && !this.lockTabletLowering)
            {
                if (this.tabletIsUp)
                {
                    this.PutTabletAway();
                }
                else 
                {
                    this.BringTabletUp();
                }
            }

        }

        private void TurnTabletOn()
        {
            this.tabletOff.GetComponent<Renderer>().enabled = false;
            this.tabletOn.GetComponent<Renderer>().enabled = true;
        }

        private void TurnTabletOff()
        {
            this.tabletOff.GetComponent<Renderer>().enabled = true;
            this.tabletOn.GetComponent<Renderer>().enabled = false;
        }

        public void BringTabletUp()
        {
            if (!this.raiseTablet)
            {
                this.raiseTablet = true;
                this.lowerTablet = false;
                this.startLerpTime = Time.time;
                this.triggeredPosition = this.transform.localPosition;
                this.movementDistance = Vector3.Distance(this.triggeredPosition, this.onScreenPosition);
            }
        }

        public void PutTabletAway()
        {
            if (!this.lowerTablet)
            {
                this.TurnTabletOff();
                this.raiseTablet = false;
                this.lowerTablet = true;
                this.startLerpTime = Time.time;
                this.triggeredPosition = this.transform.localPosition;
                this.movementDistance = Vector3.Distance(this.triggeredPosition, this.startPosition);
            }
        }
    }
}
