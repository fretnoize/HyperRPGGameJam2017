using UnityEngine;

namespace Assets.Game.Scripts
{
    public class ObjectManager : MonoBehaviour
    {
        public Transform DiscPrefab;
        public Transform DiscFolder;

        [Range(0, 10)]
        public int NumberOfDiscs = 4;

        
        public static int CurrentDisc = 0;
        //private int currentDisc = 0;

        // Use this for initialization
        void Start()
        {
            //PlayerPrefs
            DontDestroyOnLoad(this.gameObject);
            //if (PlayerPrefs.HasKey("CurrentItem"))
            //{
            //    PlayerPrefs.SetInt("CurrentItem", PlayerPrefs.GetInt("CurrentItem") + 1);
            //}
            //else
            //{
            //    PlayerPrefs.SetInt("CurrentItem", 0);
            //}
            this.DiscFolder.transform.parent = this.transform;
            var disc = GameObject.Instantiate(
                this.DiscPrefab,
                new Vector3(Random.Range(-38, 38), Random.Range(-4.5f, -3), -1),
                Quaternion.identity);
            disc.parent = this.DiscFolder.transform;
        }
    }
}
