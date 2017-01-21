using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Test_Assets
{
    using Assets.Game.Scripts;

    [RequireComponent(typeof(Button))]
    public class EndPuzzle : MonoBehaviour
    {
        public PuzzleAudio PuzzleAudio;

        public PuzzleText PuzzleText;
        private Button button;

        // Use this for initialization
        void Start()
        {
            this.button = this.GetComponent<Button>();
            this.button.onClick.AddListener(this.StartSound);
        }

        private void StartSound()
        {
            Debug.Log("Starting to play the final sound");
            this.PuzzleAudio.PlayCleanFromStart();
            this.PuzzleText.Distort(0);
        }
    }
}
