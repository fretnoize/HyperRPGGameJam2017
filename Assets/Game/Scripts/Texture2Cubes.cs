using UnityEngine;

namespace Assets.Game.Scripts
{
    using System;

    using UnityEngine.UI;

    using Random = UnityEngine.Random;

    public class Texture2Cubes : MonoBehaviour
    {

        // temp controls
        public Toggle nonRotatingCubes;

        public Toggle lockPuzzle;

        public Button spinPuzzle;

        public Slider solvedThresholdSlider;

        public Text statusText;

        private float solvedThreshold;

        public Texture2D texture2D;
        public GameObject prefab;
        public float speed = 500.0f;

        private bool mouseDown = false;

        private bool puzzleSolved = false;

        private readonly Random random = new Random();

        private GameObject cubeFolder;

        // Use this for initialization
        void Start()
        {
            this.spinPuzzle.onClick.AddListener(SpinPuzzle);
            var pixels = this.texture2D.GetPixels();
            var width = this.texture2D.width;
            var height = this.texture2D.height;

            var x = 0f;
            var y = 0f;
            var cubes = 0;

            var minX = 1025f;
            var maxX = 0f;
            var minY = 1025f;
            var maxY = 0f;
            var minZ = 1025f;
            var maxZ = 0f;

            this.cubeFolder = new GameObject { name = "Cube Folder" };
            this.cubeFolder.transform.parent = this.transform;

            Debug.Log(width + "\t" + height);
            var depth = Convert.ToSingle(width / 1.5);

            foreach (var currColor in pixels)
            {
                if (!(Math.Abs(currColor.a) < 0.001f))
                {
                    var z = Random.Range(0f, depth);
                    var cube = Instantiate(this.prefab, new Vector3(-1 * (width / 2) + x + 1.5f, -1 * (height / 2) + y - 2.5f, -1 * Convert.ToSingle(depth / 2) + z), Quaternion.identity);
                    cube.name = "Cube (" + x + ", " + y + ")";
                    cube.transform.parent = this.cubeFolder.transform;
                    var cubeRenderer = cube.GetComponent<Renderer>();
                    cubeRenderer.material.color = currColor;
                    cubes++;

                    minX = Math.Min(x, minX);
                    minY = Math.Min(y, minY);
                    minZ = Math.Min(z, minZ);

                    maxX = Math.Max(x, maxX);
                    maxY = Math.Max(y, maxY);
                    maxZ = Math.Max(z, maxZ);
                }

                x++;
                if (x >= width)
                {
                    x = 0;
                    y++;
                }
            }

            var myCollider = this.gameObject.AddComponent<BoxCollider>();
            myCollider.isTrigger = true;
            myCollider.size = new Vector3(maxX - minX + 1, maxY - minY + 1, maxZ - minZ + 1);
            Debug.Log(cubes + " cubes created.");

            this.solvedThreshold = this.solvedThresholdSlider.value;
            this.solvedThresholdSlider.onValueChanged.AddListener(this.UpdateSliderValue);
        }

        private void UpdateSliderValue(float arg0)
        {
            this.solvedThreshold = arg0;
        }

        private void SpinPuzzle()
        {
            var rotation = new Vector3(Random.Range(-90, 90), Random.Range(-90, 90), 0);
            this.SpinPuzzle(rotation);
        }

        private void SpinPuzzle(Vector3 rotation)
        {
            this.transform.Rotate(rotation, Space.World);

            if (!this.nonRotatingCubes.isOn)
            {
                foreach (Transform component in this.cubeFolder.transform)
                {
                    component.rotation = Quaternion.identity;
                }
            }
        }

        void Update()
        {
            if (this.mouseDown)
            {
                var rotation = new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * this.speed;
                this.SpinPuzzle(rotation);
            }

            this.CheckSolved();
        }

        private void CheckSolved()
        {
            var x = Math.Abs(this.transform.rotation.eulerAngles.x);
            var y = Math.Abs(this.transform.rotation.eulerAngles.y);

            while (x >= 180)
            {
                x -= 180f;
            }
            while (y >= 180f)
            {
                y -= 180f;
            }

            if ((x.CompareTo(this.solvedThreshold) < 0 || (180 - x).CompareTo(this.solvedThreshold) < 0)
                && (y.CompareTo(this.solvedThreshold) < 0 || (180 - y).CompareTo(this.solvedThreshold) < 0))
            {
                this.puzzleSolved = true;
            }
            else
            {
                this.puzzleSolved = false;
            }

            if (this.puzzleSolved)
            {
                this.statusText.text = "Status: solved";
            }
            else
            {
                this.statusText.text = "Status: NOT solved";
            }
        }

        void OnMouseDown()
        {
            this.mouseDown = true;
            if (this.lockPuzzle.isOn)
            {
                this.mouseDown = false;
            }
            Debug.Log("The mouse is down on the collider.");
        }

        void OnMouseUp()
        {
            this.mouseDown = false;
            Debug.Log("The mouse is up on the collider.");
        }
    }
}
