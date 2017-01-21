using UnityEngine;

namespace Assets.Game.Scripts
{
    [RequireComponent(typeof(AudioSource))]
    public class PuzzleAudio : MonoBehaviour
    {
        private AudioSource voAudioSource;
        private AudioSource staticAudioSource;

        private float distortionValue;

        void Start()
        {
            var availableSources = this.GetComponents(typeof(AudioSource));
            Debug.Log(availableSources.Length);
            this.voAudioSource = availableSources[0] as AudioSource;
            this.staticAudioSource = availableSources[1] as AudioSource;
            Debug.Log("Found audio sources");
        }

        /// <summary>
        /// Plays the audio from the start cleanly with no distortion.  Used for final play of audio clip.
        /// Will stop clip playing if already in progress.
        /// </summary>
        public void PlayCleanFromStart()
        {
            this.StopPlaying();
            this.voAudioSource.loop = false;
            this.voAudioSource.volume = 1;
            this.voAudioSource.Play();
        }

        /// <summary>
        /// Will play the audio from the start in a loop.  Will stop clip playing if already in progress.
        /// </summary>
        public void PlayLooped()
        {
            this.StopPlaying();
            this.voAudioSource.loop = true;
            this.Distort(0.0f);
            this.voAudioSource.Play();
            this.staticAudioSource.loop = true;
            this.staticAudioSource.Play();
        }

        /// <summary>
        /// Stops the playing of the audio clip if already in progress.
        /// </summary>
        public void StopPlaying()
        {
            if (this.voAudioSource.isPlaying)
            {
                this.voAudioSource.Stop();
            }
            if (this.staticAudioSource.isPlaying)
            {
                this.staticAudioSource.Stop();
            }
        }

        /// <summary>
        /// Will fade from one audio source to another.  1.0 is completely to the first audio source and 0.0 is to the 2nd one.
        /// </summary>
        /// <param name="distortionValue">The amounf to distort by clamped to 0.0f to 1.0f</param>
        public void Distort(float distortionValue)
        {
            if (!this.voAudioSource.loop)
            {
                return;
            }
            this.distortionValue = Mathf.Clamp(distortionValue, 0.0f, 1.0f);
            this.voAudioSource.volume = distortionValue;
            this.staticAudioSource.volume = 1.0f - distortionValue;
        }
    }
}
