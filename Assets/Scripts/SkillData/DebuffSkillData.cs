using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Debuff skill for reducing enemy stats
[CreateAssetMenu(fileName = "New Debuff Skill", menuName = "Skills/Debuff Skill")]
public class DebuffSkillData : SkillData
{    private void OnEnable()
    {
        skillType = "Debuff"; 
    }
}