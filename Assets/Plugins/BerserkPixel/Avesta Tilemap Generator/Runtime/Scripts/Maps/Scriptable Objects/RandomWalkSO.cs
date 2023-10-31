using System;
using BerserkPixel.Tilemap_Generator.Attributes;
using UnityEngine;

namespace BerserkPixel.Tilemap_Generator.SO
{
    [CreateAssetMenu(fileName = "New Map Configuration", menuName = "Avesta/Maps/Random Walk")]
    public class RandomWalkSO : MapConfigSO, IEquatable<RandomWalkSO>
    {
        [DelayedCallback(nameof(MapChange)), Range(0, 100)]
        public float fillPercent = 50;

        [DelayedCallback(nameof(MapChange))]
        public string seed;
        
        [DelayedCallback(nameof(MapChange))]
        public bool invert;
        
        [DelayedCallback(nameof(MapChange))]
        public Vector2Int startingPoint = Vector2Int.zero;
        
        [DelayedCallback(nameof(MapChange))]
        public int maxIterations = 1500;

        public override bool Equals(MapConfigSO map)
        {
            var other = map as RandomWalkSO;

            return Equals(other);
        }

        public bool Equals(RandomWalkSO other)
        {
            return other != null &&
                   Math.Abs(fillPercent - other.fillPercent) < _compareThreshold &&
                   string.Compare(seed, other.seed, StringComparison.CurrentCulture) == 0 &&
                   invert == other.invert &&
                   startingPoint.Equals(other.startingPoint) &&
                   maxIterations == other.maxIterations;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hash = (int) 2166136261;
                // Suitable nullity checks etc, of course :)
                hash = hash * 16777619 + seed.GetHashCode();
                hash = hash * 16777619 + fillPercent.GetHashCode();
                hash = hash * 16777619 + invert.GetHashCode();
                hash = hash * 16777619 + startingPoint.GetHashCode();
                hash = hash * 16777619 + maxIterations.GetHashCode();
                return hash;
            }
        }
    }
}