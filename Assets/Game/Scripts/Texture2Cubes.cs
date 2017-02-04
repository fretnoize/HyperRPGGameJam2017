using UnityEngine;

namespace Assets.Game.Scripts
{
    using System;

    using UnityEngine.UI;

    using System.Collections;

    using Random = UnityEngine.Random;

    public class Texture2Cubes : MonoBehaviour
    {

        public float solvedThreshold = 2f;

        public Texture2D[] texture2D = new Texture2D[4];
        public GameObject prefab;
        public float speed = 500.0f;

        [Tooltip("Destination is just a visual aid, keep at 0,0,0")]
        public GameObject DestinationMarker;
        [Tooltip("Center of horizontal plane PixelCubes spawn at")]
        public GameObject StartMarker;
        [Tooltip("Length and depth of the area PixelCubes can randomly spawn")]
        public float StartArea;

        public float MinFormTime, MaxFormTime;

        private Vector3 startMarkerLocation;

        private bool mouseDown = false;

        private bool puzzleSolved = false;

        private GameObject cubeFolder;

        public int textNum;

        // lerping for orientation
        private Quaternion rotationStart;

        private Quaternion rotationTarget;

        private float startLerpTime;

        private bool rotationComplete = true;

        private void Awake()
        {
            //startMarkerLocation = StartMarker.transform.localPosition;
            //Destroy(StartMarker);
            //Destroy(DestinationMarker);
        }

        private void OnEnable()
        {
            startMarkerLocation = StartMarker.transform.localPosition;
            StartMarker.SetActive(false);
            DestinationMarker.SetActive(false);
        }

        void Start()
        {
            //StartCoroutine(StartPuzzle());
            StartPuzzle();
        }

        private void SpinPuzzle()
        {
            var rotation = new Vector3(Random.Range(-90, 90), Random.Range(-90, 90), 0);
            this.SpinPuzzle(rotation);
        }

        private void SpinPuzzle(Vector3 rotation)
        {
            this.transform.Rotate(rotation, Space.World);
        }

        void Update()
        {
            if (this.mouseDown && this.gameObject.GetComponent<Collider>().enabled)
            {
                var rotation = new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * this.speed;
                this.SpinPuzzle(rotation);
            }

            if (!this.puzzleSolved)
            {
                this.CheckSolved();
            }
            else if (!this.rotationComplete)
            {
                var angle = Quaternion.Angle(this.rotationStart, this.rotationTarget);
                var distCovered = (Time.time - this.startLerpTime) * 40f;
                var fracJourney = distCovered / angle;

                this.transform.rotation = Quaternion.Lerp(this.rotationStart, this.rotationTarget, fracJourney);
            }
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
                this.gameObject.GetComponent<Collider>().enabled = false;

                this.rotationStart = this.transform.rotation;
                this.rotationTarget = Quaternion.Euler(new Vector3(this.getNearestFlatAngle(this.rotationStart.eulerAngles.x), this.getNearestFlatAngle(this.rotationStart.eulerAngles.y), 0));
                this.startLerpTime = Time.time;
                this.rotationComplete = false;
            }
            else
            {
                this.puzzleSolved = false;
            }
        }

        private float getNearestFlatAngle(float currAngle)
        {
            if (currAngle <= -270)
            {
                return -360f;
            } else if (currAngle <= -90)
            {
                return -180f;
            }
            else if (currAngle <= 90)
            {
                return 0f;
            }
            else if (currAngle <= 270)
            {
                return 180f;
            }
            else
            {
                return 360f;
            }
        }

        public bool isPuzzleSolved()
        {
            return this.puzzleSolved;
        }

        public float completionCloseness()
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

            var xDiff = Math.Min(x, (180 - x));
            var yDiff = Math.Min(y, (180 - y));

            var result = (xDiff + yDiff) / 360 * 2;

            return result;
        }

        void OnMouseDown()
        {
            this.mouseDown = true;
            //Debug.Log("The mouse is down on the collider.");
        }

        void OnMouseUp()
        {
            this.mouseDown = false;
            //Debug.Log("The mouse is up on the collider.");
        }

        private void StartPuzzle()
        {
            //yield return new WaitForSeconds(0.5f);


            var textureIndex = ObjectManager.CurrentDisc; // textNum;
            //if (PlayerPrefs.HasKey("CurrentItem"))
            //{
            //    textureIndex = PlayerPrefs.GetInt("CurrentItem");
            //}
            var pixels = this.texture2D[textureIndex].GetPixels();
            var width = this.texture2D[textureIndex].width;
            var height = this.texture2D[textureIndex].height;

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

            //Debug.Log(width + "\t" + height);
            var depth = Convert.ToSingle(width / 1.5);

            foreach (var currColor in pixels)
            {
                if (!(Math.Abs(currColor.a) < 0.001f))
                {
                    var z = Random.Range(0f, depth);
                    var cube = Instantiate(this.prefab,
                        new Vector3(-1 * (width / 2) + x + 1.5f,
                        -1 * (height / 2) + y - 2.5f,
                        -1 * Convert.ToSingle(depth / 2) + z), Quaternion.identity);

                    cube.name = "Cube (" + x + ", " + y + ")";
                    cube.transform.parent = this.cubeFolder.transform;
                    var cubeRenderer = cube.GetComponent<Renderer>();
                    cubeRenderer.material.color = currColor;
                    cubes++;

                    cube.GetComponent<PixelCube>().SetStart(startMarkerLocation, StartArea, MinFormTime, MaxFormTime, cubeFolder.transform);
                    //cube.transform.parent = null;
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
            //Debug.Log(cubes + " cubes created.");

            SpinPuzzle();
        }
    }
}
