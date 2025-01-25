using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnusedSkillContainerGUI : MonoBehaviour, IDropHandler
{
    public BattleSlot slot;
    private RectTransform rectTransform;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();    
    }

    public void OnDrop(PointerEventData eventData){
        if (eventData.pointerDrag != null && eventData.pointerDrag.CompareTag("MyBattleSkillGUI")) {
            eventData.pointerDrag.GetComponent<BattleSkillGUI>().previousSlot = gameObject;
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rectTransform.position;
        }
    }
}
