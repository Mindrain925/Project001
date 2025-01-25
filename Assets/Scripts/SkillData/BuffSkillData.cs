using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Buff skill for enhancing stats
[CreateAssetMenu(fileName = "New Buff Skill", menuName = "Skills/Buff Skill")]
public class BuffSkillData : SkillData
{    private void OnEnable()
    {
        skillType = "Buff"; 
    }
}