using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Defense skill for protection
[CreateAssetMenu(fileName = "New Defense Skill", menuName = "Skills/Defense Skill")]
public class DefenseSkillData : SkillData
{    private void OnEnable()
    {
        skillType = "Defense"; 
    }
}