using System;

using UnityEngine;

namespace Assets.Game.Scripts
{
    using System.Text;

    using Random = System.Random;

    public class PuzzleText : MonoBehaviour
    {
        public String TextValue;
        private readonly Random random = new Random();

        private float distortionAmount;

        public void Distort(float distortionAmount)
        {
            this.distortionAmount = distortionAmount;
        }

        public string GetDisplayValue()
        {
            var length = this.TextValue.Length;
            var result = new StringBuilder(length);

            if (Math.Abs(1.0f - this.distortionAmount) <= .01f)
            {
                return this.TextValue;
            }

            for (var i = 0; i < length; i++)
            {
                if (this.random.NextDouble() > this.distortionAmount)
                {
                    result.Append(Convert.ToChar(Convert.ToInt32(this.random.NextDouble() * 94 + 32)));
                }
                else
                {
                    result.Append(this.TextValue.ToCharArray()[i]);
                }
            }

            return result.ToString();
        }
    }
}
