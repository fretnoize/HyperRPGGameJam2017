using UnityEngine;

namespace Assets.Game.Scripts
{
    public class ObjectManager : MonoBehaviour
    {
        public Transform DiscPrefab;
        public Transform DiscFolder;

        [Range(0, 10)]
        public int NumberOfDiscs = 4;
        public float spreadOfDiscs = 4;

        private Vector3[] spawns;

        // Use this for initialization
        void Start()
        {
            this.DiscFolder.transform.parent = this.transform;
            spawns = new Vector3[NumberOfDiscs];

            for (var i = 0; i < this.NumberOfDiscs; i++)
            {
                var location = new Vector3(Random.Range(-38, 38), Random.Range(-4.5f, -3), -1);

                // spreads out disc spawns. If `spreadOfDiscs` is too large this might take a while
                // a limited while-loop
                for (var j = 0; j < 100; j++)
                {
                    location = new Vector3(Random.Range(-38, 38), Random.Range(-4.5f, -3), -1);
                    if (i == 0 || Proximity(location))
                    {
                        break;
                    }
                    if (j == 99)
                    {
                        Debug.LogError("Too many disc spawn attempts");
                    }
                }

                spawns[i] = location;

                var disc = GameObject.Instantiate(
                    this.DiscPrefab,
                    location,
                    Quaternion.identity);
                disc.name = "Disc " + i;
                disc.parent = this.DiscFolder.transform;
            }
        }

        public int GetAvailableDiscCount()
        {
            return this.DiscFolder.childCount;
        }

        private bool Proximity(Vector3 location) {
            foreach (var spawn in spawns)
            {
                if ((location - spawn).magnitude < spreadOfDiscs)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
