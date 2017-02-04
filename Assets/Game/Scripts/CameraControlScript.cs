using UnityEngine;

namespace Assets.Game.Scripts
{
    public class CameraControlScript : MonoBehaviour
    {
        // `public` allows this parameter to be adjusted within the Unity UI, convenient for those outside of the Programming team
        public float xspeed = 20;

        // this is the backdrop texture/sprite for the scene, used to tell the camera where the edge of the scene is
        public SpriteRenderer backdrop;

        public NewsPaperController NewsCntl;

        // Use this for initialization
        private void Start ()
        {
            // debugging in case of a missing backdrop texture
            if (this.backdrop == null) {
                this.backdrop = FindObjectOfType<SpriteRenderer>();
                if (this.backdrop != null) {
                    Debug.Log("backdrop not assigned, using first found SpriteRenderer.\n");
                }
                else {
                    Debug.LogError("There's no backdrop! Please add a backdrop and assign it to this.\n");
                }
            }
        }

        // LateUpdate is called once per frame, after all items have been processed in `Update`
        // So that the player or any other objects have moved and updated
        void LateUpdate ()
        {
            // early exit for when paused
            if (!UiController.optionsMenu || !UiController.mainMenu)
            {
                return;
            }

            // seems a more general form of getting "left/right" user input. Both arrow keys and WASD
            var moveHorizontal = 0.0f;
            if (!NewsCntl.NewsPaperInputLock)
                moveHorizontal = Input.GetAxis ("Horizontal");

            // wrapping the camera to the other side of the scene
            // `backdrop.bounds.max.x` is the rightmost edge of the backdrop (pos x) while `min` is the leftmost edge
            if (this.transform.position.x > this.backdrop.bounds.max.x) {
                // seems the `z` variable needs to be set to -10, at least occasionally. Otherwise the camera will end up at z = 1
                this.transform.position = new Vector3 (this.backdrop.bounds.min.x, 0, -10);
            } else if (this.transform.position.x < this.backdrop.bounds.min.x) {
                this.transform.position = new Vector3 (this.backdrop.bounds.max.x, 0, -10);
            }

            // `Input.GetAxis ("Horizontal")` allows a single `Translate` statement and does the work of "left/right" for us
            var movement = new Vector2 (moveHorizontal, 0);

            this.transform.Translate (movement * this.xspeed * Time.deltaTime);
        }
    }
}
