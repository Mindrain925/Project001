using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSlot : ScriptableObject
{
    public SlotData DefaultSlotData { get; private set; }
    public BattleSkill attachedSkill;
    public int combatATK;
    public int combatDEF;
    public int combatHP;
    public int combatSpeed;
    public int priority;
    public bool readyToFight;

    public void Initialize(SlotData slotData)
    {
        if (slotData == null)
        {
            Debug.LogError("SlotData is null during BattleSlot initialization.");
            return;
        }

        DefaultSlotData = slotData;
        combatATK = DefaultSlotData.ATK;
        combatDEF = DefaultSlotData.DEF;
        combatHP = DefaultSlotData.HP;
        combatSpeed = DefaultSlotData.Speed;

        priority = -1;
        readyToFight = false;
    }

    // Property for attachedSkill
    public BattleSkill AttachedSkill
    {
        get => attachedSkill;
    }

    public void SetAttachedSkill(BattleSkill skill = null)
    {
        attachedSkill = skill;
    }
}
