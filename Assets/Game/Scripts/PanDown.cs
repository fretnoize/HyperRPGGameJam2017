using UnityEngine;

namespace Assets.Game.Scripts
{
    public class PanDown : MonoBehaviour
    {
        // enables speed adjustment in Unity UI
        public float Speed;

        // disables the pan until "Play Game" is clicked and thus `Pan ()` is called
        private bool clicked = false;

        // Update is called once per frame
        void Update()
        {
            // if "Play Game" was clicked, start to pan down every frame
            if (this.clicked)
            {
                this.transform.Translate(0, -this.transform.position.y * this.Speed * Time.deltaTime, 0);
            }
        }

        // starts panning down
        public void Pan()
        {
            this.clicked = true;
        }
    }
}
