using BrightLib.Scrubbing.Runtime;
using UnityEngine;

namespace BrightLib.Scrubbing.Samples
{
    [CreateAssetMenu(menuName = nameof(SkillData))]
    public class SkillData : ScriptableObject, IFancyScrubData
    {
        public string description;
        public int useCost;
        public bool boolTest;

        public int[] arrayIntTest;

        public SkillEffect[] effects;
    }
}