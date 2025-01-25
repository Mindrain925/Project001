using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cooperate skill for team actions
[CreateAssetMenu(fileName = "New Cooperate Skill", menuName = "Skills/Cooperate Skill")]
public class CooperateSkillData : SkillData
{    private void OnEnable()
    {
        skillType = "Cooperate"; 
    }
}