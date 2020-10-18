using BrightLib.Scrubbing.Runtime;
using UnityEngine;

namespace BrightLib.Scrubbing.Samples
{
    [FancyScrubData]
    [CreateAssetMenu(menuName = nameof(SkillData))]
    public class SkillData : ScriptableObject
    {
        public string displayName;
        public string description;
        public int mpCost;
        public bool boolTest;

        public int[] arrayIntTest;

        public SkillEffect[] effects;
    }
}