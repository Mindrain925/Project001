using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSkill : ScriptableObject
{
    public GameObject defaultSkill { get; private set; }
    public GameObject battleSkill;
    
    // Initialization method
    public void Initialize(GameObject skill)
    {
        if (skill == null)
        {
            Debug.LogError("Skill parameter is null when initializing BattleSkill.");
            return;
        }

        defaultSkill = skill;
        battleSkill = defaultSkill;
    }

    public void Execute()
    {
        if (defaultSkill == null)
        {
            Debug.LogError("Cannot execute because defaultSkill is null.");
            return;
        }

        battleSkill.GetComponent<Skill>().Execute();
    }
}
