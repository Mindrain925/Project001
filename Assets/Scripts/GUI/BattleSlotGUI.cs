using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

class BattleSlotGUI : MonoBehaviour, 
IDropHandler,
IPointerDownHandler
{
    public BattleSlot slot;
    private RectTransform rectTransform;
    public GameObject attachedBattleSkillGUI;
    private bool isAttached = false;
    //private SlotState state;
    public bool IsAttached{
        get { return isAttached;} 
        set { isAttached = value; }
    }
    [SerializeField] TextMeshProUGUI slotAtkText;
    [SerializeField] TextMeshProUGUI slotDefText;

    private void Start() {
        rectTransform = GetComponent<RectTransform>();    

        // Set Slot State UI, if slot is not null
        //* Because BattleSlotGUI initializeing is later than Slot initializing,
        //* this code should be in Start() : not Awake()
        if (slot != null){
            slotAtkText.text = slot.combatATK.ToString();
            slotDefText.text = slot.combatDEF.ToString();
        }
    }

    //This code is about skill attaching
    public void OnDrop(PointerEventData eventData){
        //MyBattleSkillGUI and EnemyBattleSlotGUI GameObjects are attactehd with BattleSlotGUI class.
        //All of usages of the functions are the same for the two types of GameObjects
        //execpt for OnDrop function doing its function until the tag of the GameObject is "MyBattleSlotGUI"
        if (eventData.pointerDrag != null 
            && eventData.pointerDrag.CompareTag("MyBattleSkillGUI") 
            && !isAttached 
            && gameObject.CompareTag("MyBattleSlotGUI")) {
            //* This may causes coupling with BattleSkillGUI
            // eventData.pointerDrag.GetComponent<CanvasGroup>().blocksRaycasts = true;
            
            eventData.pointerDrag.GetComponent<BattleSkillGUI>().previousSlot = gameObject;
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rectTransform.position;
            

            attachedBattleSkillGUI = eventData.pointerDrag;
            isAttached = true;
        }
    }

    //This code is about showing skill info
    public void OnPointerDown(PointerEventData eventData){
        if (Input.GetMouseButtonDown(0)){
            BattleSlotInfoModalManager.Instance.Execute(gameObject);
        }
    }

    // //This code is about showing the info of Slot
    // private bool isHovering = false; 
    // private Coroutine hoverCoroutine;

    // public void OnPointerEnter(PointerEventData eventData)
    // {
    //     isHovering = true;
    //     hoverCoroutine = StartCoroutine(StartHover());
    //     Debug.Log("시발");
    // }

    // public void OnPointerExit(PointerEventData eventData)
    // {
    //     if (hoverCoroutine != null)
    //     {
    //         StopCoroutine(hoverCoroutine);
    //     }
        
    //     isHovering = false;
    // }

    // private IEnumerator StartHover()
    // {
    //     yield return new WaitForSeconds(1f); 
    //     // ? If the argument is variable, WaitForSeconds() functions in very werid way
    //     // ? -> 'int' type argument : real executing time is 2.00xxx, 'float' type argument : real executing time is 0.20xxx, 

    //     if (isHovering && isAttached)
    //     {      
    //         BattleSlotInfoModalManager.Instance.Execute(gameObject);
    //     }
    // }
}
