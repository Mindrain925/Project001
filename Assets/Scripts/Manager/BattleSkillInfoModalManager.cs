using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleSkillInfoModalManager : MonoBehaviour
{
    public static BattleSkillInfoModalManager Instance { get; private set; }
    [SerializeField] private GameObject battleSkillInfoModal;
    [SerializeField] private GameObject panel;
    private BattleSkillInfoModalPanel battleSkillInfoModalPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make it persist across scenes

            battleSkillInfoModalPanel = panel.GetComponent<BattleSkillInfoModalPanel>();

        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }
    }

    public void Execute(GameObject battleSkillGUI)
    {
        battleSkillInfoModal.transform.GetChild(0).gameObject.SetActive(true); // The activated GameObejct must be 'Panel'

        battleSkillInfoModalPanel.SetSkillSlotDataText(battleSkillGUI);
    }
    
    // * This code causes code complexity, Need to be refactored
    public void Close(){
        panel.GetComponent<BattleSkillInfoModalPanel>().ClosePanel();
    }
}