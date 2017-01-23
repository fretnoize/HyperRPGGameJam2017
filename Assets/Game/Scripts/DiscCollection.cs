using UnityEngine;

namespace Assets.Game.Scripts
{
    using UnityEngine.SceneManagement;

    public class DiscCollection : MonoBehaviour
    {
        private bool animating = false;

        private float lerpLength = 2f;
        private Vector3 startScale;

        private float startTime;

        private bool levelLoaded = true;

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

                if (Time.time >= this.startTime + this.lerpLength)
                {
                    levelLoaded = true;
                    if (ObjectManager.CurrentDisc > 3)
                    {
                        Debug.LogError("Hey, i don't know anything more than 4 discs");
                        return;
                    }
                    Debug.Log("Current disc: " + ObjectManager.CurrentDisc + "\n");
                    switch (ObjectManager.CurrentDisc)
                    {
                        case 0:
                            SceneManager.LoadScene("Puzzle Demo");
                            break;
                        case 1:
                            SceneManager.LoadScene("Puzzle Demo1");
                            break;
                        case 2:
                            SceneManager.LoadScene("Puzzle Demo2");
                            break;
                        case 3:
                            SceneManager.LoadScene("Puzzle Demo3");
                            break;
                    }

                    //SceneManager.LoadScene("Puzzle Demo");
                    
                    DestroyObject(this.gameObject);
                }
            }
        }

        void OnMouseDown()
        {
            if (!this.animating && UiController.optionsMenu && UiController.mainMenu)
            {
                this.startTime = Time.time;
                this.animating = true;
                levelLoaded = false;
            }
        }
    }
}
