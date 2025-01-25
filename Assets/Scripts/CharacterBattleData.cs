using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Character Battle Data", menuName = "CharacterBattleData")]
public class CharacterBattleData : ScriptableObject
{
    [SerializeField] private string characterName;
    [SerializeField] private GameObject[] equipedSkills;
    [SerializeField] private SlotData[] equipedSlotsData;

    public GameObject[] EquipedSkills => equipedSkills;
    public SlotData[] EquipedSlotsData => equipedSlotsData;
}
