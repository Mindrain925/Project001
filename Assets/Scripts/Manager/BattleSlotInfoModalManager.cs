using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSlotInfoModalManager : MonoBehaviour
{
    public static BattleSlotInfoModalManager Instance { get; private set; }
    [SerializeField] private GameObject battleSlotModal;
    [SerializeField] private GameObject panel;
    private BattleSlotInfoModalPanel battleSlotInfoModalPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make it persist across scenes

            battleSlotInfoModalPanel = panel.GetComponent<BattleSlotInfoModalPanel>();
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }
    }

    public void Execute(GameObject battleSlotGUI)
    {
        battleSlotModal.transform.GetChild(0).gameObject.SetActive(true); // The activated GameObejct must be 'Panel'

        battleSlotInfoModalPanel.SetBattleSlotStateText(battleSlotGUI);

        // BattleSkillInfoModalManager.Instance.Execute(battleSlotGUI.GetComponent<BattleSlotGUI>().attachedBattleSkillGUI.GetComponent<BattleSkillGUI>().)
    }
}
