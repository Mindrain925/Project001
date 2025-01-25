using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleFieldCharacter : MonoBehaviour
{
    public CharacterBattleData defaultCharacterBattleData;
    public List<BattleSlot> battleSlotsData = new List<BattleSlot>();
    public List<BattleSkill> battleSkillData = new List<BattleSkill>();
    public List<GameObject> battleSkillGUI = new List<GameObject>();
    public List<GameObject> battleSkill = new List<GameObject>();
    public List<GameObject> battleSlotGUI = new List<GameObject>();
    public List<GameObject> battleSlot = new List<GameObject>();
    public Sprite portrait;

    public void Initialize() {
        for (int i = 0; i < defaultCharacterBattleData.EquipedSkills.Length; i++) {
            battleSkillData.Add(ScriptableObject.CreateInstance<BattleSkill>());
            battleSkillData[i].Initialize(defaultCharacterBattleData.EquipedSkills[i]);
            battleSkillData[i].name = battleSkillData[i].defaultSkill.GetComponent<Skill>().SkilData.Name;
        }
        
        for (int i = 0; i < defaultCharacterBattleData.EquipedSlotsData.Length; i++) {
            battleSlotsData.Add(ScriptableObject.CreateInstance<BattleSlot>());
            battleSlotsData[i].Initialize(defaultCharacterBattleData.EquipedSlotsData[i]);
            battleSlotsData[i].name = "Battle Slot " + i.ToString();
        }
    }

    // private void Update() {
    //     if (Input.GetKeyDown(KeyCode.Alpha1)){
    //         battleSkillData[0].Execute();
    //     }
    //     if (Input.GetKeyDown(KeyCode.Alpha2)){
    //         battleSkillData[1].Execute();
    //     }
    // }
}
