using UnityEngine;

namespace Assets.Game.Scripts
{
    public class ObjectManager : MonoBehaviour
    {
        public Transform DiscPrefab;
        public Transform DiscFolder;

        public static ObjectManager Instance;

        [Range(0, 10)]
        public int NumberOfDiscs = 4;

        
        public static int CurrentDisc = 0;
        //private int currentDisc = 0;

        // Use this for initialization
        void Start()
        {
            if (CurrentDisc >= NumberOfDiscs)
            {
                //the game is finished, display the tablet w/end text
                FindObjectOfType<TabletController>().DisplayEndText();
            }
            else
            {
                //spawn a new disc
                this.DiscFolder.transform.parent = this.transform;
                var disc = GameObject.Instantiate(
                    this.DiscPrefab,
                    new Vector3(Random.Range(-38, 38), Random.Range(-4.5f, -3), -1),
                    Quaternion.identity);
                if (Instance == null)
                {
                    disc.parent = this.DiscFolder.transform;
                }
                else
                {
                    disc.parent = Instance.gameObject.transform;
                }
            }

            if (Instance == null)
            {
                DontDestroyOnLoad(this.gameObject);
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }
    }
}
