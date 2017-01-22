using UnityEngine;

namespace Assets.Game.Scripts
{
    public class ObjectManager : MonoBehaviour
    {
        public Transform DiscPrefab;
        public Transform DiscFolder;

        [Range(0, 10)]
        public int NumberOfDiscs = 4;

        // Use this for initialization
        void Start()
        {
            this.DiscFolder.transform.parent = this.transform;
            for (var i = 0; i < this.NumberOfDiscs; i++)
            {
                var disc = GameObject.Instantiate(
                    this.DiscPrefab,
                    new Vector3(Random.Range(-45, 45), Random.Range(-4.5f, -3), -1),
                    Quaternion.identity);
                disc.name = "Disc " + i;
                disc.parent = this.DiscFolder.transform;
            }
        }

        public int GetAvailableDiscCount()
        {
            return this.DiscFolder.childCount;
        }
    }
}
