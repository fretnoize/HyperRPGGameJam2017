using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Test_Assets
{
    using Assets.Game.Scripts;

    [RequireComponent(typeof(Button))]
    public class StartPuzzle : MonoBehaviour
    {
        public PuzzleAudio PuzzleAudio;
        public PuzzleText PuzzleText;
        public Text TextArea;
        private Button button;

        public Slider slider;

        private float nextTextUpdate;

        private readonly float updateDiff = 0.3f;

        // Use this for initialization
        void Start ()
        {
            this.button = this.GetComponent <Button>();
            this.button.onClick.AddListener(this.StartSound);
            this.slider.onValueChanged.AddListener(this.Distort);
            this.nextTextUpdate = Time.time + this.updateDiff;
        }

        void Update()
        {
            if (Time.time >= this.nextTextUpdate)
            {
                this.TextArea.text = this.PuzzleText.GetDisplayValue();
                this.nextTextUpdate = Time.time + this.updateDiff;
            }
            
        }

        private void Distort(float distortionValue)
        {
            this.PuzzleAudio.Distort(distortionValue);
            this.PuzzleText.Distort(distortionValue);
        }

        private void StartSound()
        {
            Debug.Log("Starting to play the looped sound");
            this.PuzzleAudio.PlayLooped();
        }
    }
}
