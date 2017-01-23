﻿using UnityEngine;

namespace Assets.Game.Scripts
{
    public class ObjectManager : MonoBehaviour
    {
        public Transform DiscPrefab;
        public Transform DiscFolder;

        public Transform Puzzle;

        [Range(0, 10)]
        public int NumberOfDiscs = 4;
        [Range(0, 75)]
        public float spreadOfDiscs;

        public Texture2D[] puzzles = new Texture2D[4];

        // Use this for initialization
        void Start()
        {
            this.DiscFolder.transform.parent = this.transform;
            var spawns = new Vector3[NumberOfDiscs];

            for (var i = 0; i < this.NumberOfDiscs; i++)
            {
                var location = new Vector3(Random.Range(-38, 38), Random.Range(-4.5f, -3), -1);

                // spreads out disc spawns. If `spreadOfDiscs` is too large this might take a while
                for (var j = 0; j < 100; j++)
                {
                    location = new Vector3(Random.Range(-38, 38), Random.Range(-4.5f, -3), -1);
                    if (i == 0 || (location - spawns[i - 1]).magnitude > spreadOfDiscs)
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

                DiscCollection discCollection = disc.GetComponent<DiscCollection>();
                discCollection.objectManager = this;
            }
        }

        public int GetAvailableDiscCount()
        {
            return this.DiscFolder.childCount;
        }

        public void removeDisc(DiscCollection discCollection)
        {
            var removedIndex = this.NumberOfDiscs - this.GetAvailableDiscCount();
            Debug.Log("Disc number " + removedIndex + " has been removed.");
            Destroy(discCollection.gameObject, 1);

            var texture2Cubes = this.Puzzle.GetComponent<Texture2Cubes>();
            texture2Cubes.LoadImage(this.puzzles[removedIndex]);
        }
    }
}
