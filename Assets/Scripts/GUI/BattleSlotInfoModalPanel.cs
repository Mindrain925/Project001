using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BattleSlotInfoModalPanel : MonoBehaviour
{   
    [SerializeField] private BattleSlotGUI battleSlotGUIScript;
    [SerializeField] private TextMeshProUGUI slotAtkText;
    [SerializeField] private TextMeshProUGUI slotDefText;
    [SerializeField] private TextMeshProUGUI slotSpeedText;
    [SerializeField] private TextMeshProUGUI slotHpText;
    [SerializeField] private TextMeshProUGUI attachedSkillName;
    [SerializeField] private GameObject UnslotSkillButton;
    private Transform previousParent;
    private GameObject battleSlotGUI;

    public void SetBattleSlotStateText(GameObject _battleSlotGUI){
        battleSlotGUI = _battleSlotGUI;
        battleSlotGUIScript = battleSlotGUI.GetComponent<BattleSlotGUI>();

        BattleSlot battleSlot = battleSlotGUI.GetComponent<BattleSlotGUI>().slot;

        slotAtkText.text = "Slot ATK : " + battleSlot.combatATK.ToString();
        slotDefText.text = "Slot DEF : " + battleSlot.combatDEF.ToString();
        slotSpeedText.text = "Slot Speed : " + battleSlot.combatSpeed.ToString();
        slotHpText.text = "Slot Hp : " + battleSlot.combatHP.ToString();

        if (battleSlotGUI.GetComponent<BattleSlotGUI>().IsAttached){
            UnslotSkillButton.SetActive(true);
            BattleSkillInfoModalManager.Instance.Execute(battleSlotGUI.GetComponent<BattleSlotGUI>().attachedBattleSkillGUI);
        }
        else{
            UnslotSkillButton.SetActive(false);
        }

        //* Hightlighting the selected battleSlotGUI
        previousParent = battleSlotGUI.transform.parent;
        battleSlotGUI.transform.SetParent(gameObject.transform);
    }

    public void ClosePanel(){
        gameObject.SetActive(false);

        battleSlotGUI.transform.SetParent(previousParent);

        BattleSkillInfoModalManager.Instance.Close();
    }

    //This causes coupling
    public void UnslotSkill(){
        battleSlotGUIScript.IsAttached = false;
        
        battleSlotGUIScript.attachedBattleSkillGUI.GetComponent<BattleSkillGUI>().Unslot();

        UnslotSkillButton.SetActive(false);
        ClosePanel();
    }
}
