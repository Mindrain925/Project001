using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Analyze skill for information gathering
[CreateAssetMenu(fileName = "New Analyze Skill", menuName = "Skills/Analyze Skill")]
public class AnalyzeSkillData : SkillData
{    private void OnEnable()
    {
        skillType = "Analyze"; 
    }
}
