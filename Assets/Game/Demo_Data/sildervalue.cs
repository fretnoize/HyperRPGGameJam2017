using UnityEngine;

namespace Assets.Game.Demo_Data
{
    using System;

    using UnityEngine.UI;

    public class sildervalue : MonoBehaviour
    {
        public Slider slider;

        public Text text;

        // Use this for initialization
        void Start () {
		    this.slider.onValueChanged.AddListener(updateMeh);
            this.text.text = String.Format("{0:0.00}", this.slider.value);
        }

        private void updateMeh(float arg0)
        {
            this.text.text = String.Format("{0:0.00}", arg0);
        }
    }
}
