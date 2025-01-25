using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleSkillInfoModalPanel : MonoBehaviour
{
    [SerializeField] private Image skillImage;
    [SerializeField] private TextMeshProUGUI skillTypeText;
    [SerializeField] private TextMeshProUGUI skillCoolTimeText;
    [SerializeField] private TextMeshProUGUI skillNameText;
    [SerializeField] private TextMeshProUGUI skillContentText;

    public void SetSkillSlotDataText(GameObject battleSkillGUI){
        SkillData battleSkillData = battleSkillGUI.GetComponent<BattleSkillGUI>().skill.GetComponent<Skill>().SkilData;

        skillImage.sprite = battleSkillData.Icon;
        skillTypeText.text = battleSkillData.Type;
        skillCoolTimeText.text = "Cool Time : " + battleSkillData.CoolDown;
        skillNameText.text = battleSkillData.Name;
        skillContentText.text = battleSkillData.Content;
    }

    public void ClosePanel(){
        gameObject.SetActive(false);
    }
}
