using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attack skill for information gathering
[CreateAssetMenu(fileName = "New Attack Skill", menuName = "Skills/Attack Skill")]
public class AttackSkillData : SkillData
{
    private void OnEnable()
    {
        skillType = "Attack"; 
    }
}