using BrightLib.Scrubbing.Runtime;
using UnityEngine;

namespace BrightLib.Scrubbing.Samples
{
    [CreateAssetMenu(menuName = nameof(ItemData))]
    public class ItemData : ScriptableObject, IScrubData
    {
        public string displayName = "Awesome item";
        public string description = "Please buy me";
        public int cost;
        public bool canBeSold = true;
    }
}