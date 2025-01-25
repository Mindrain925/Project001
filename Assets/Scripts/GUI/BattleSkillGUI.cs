using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class BattleSkillGUI : 
MonoBehaviour, 
IBeginDragHandler, IDragHandler, IEndDragHandler, 
IPointerEnterHandler, IPointerExitHandler
{
    public GameObject skill;
    public GameObject canvas;
    public GameObject defaultUnusedSkillContainer;
    public GameObject previousSlot;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public AudioClip slotEffectSound;
    public AudioClip unslotEffectSound;
    // public bool isAttachedTo = false; 

    // private void Awake() {
    //     rectTransform = GetComponent<RectTransform>();
    //     canvasGroup = GetComponent<CanvasGroup>();

    //     previousSlot = defaultUnusedSkillContainer;
    //     transform.SetParent(previousSlot.transform);
    // }

    public void Initialize(){
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        previousSlot = defaultUnusedSkillContainer;
        transform.SetParent(previousSlot.transform);
    }
    
    public void Unslot(){
        previousSlot = defaultUnusedSkillContainer;
        transform.SetParent(previousSlot.transform);
        canvasGroup.blocksRaycasts = true;
    }

    //This code is about skill attaching
    public void OnBeginDrag(PointerEventData eventData){
        //This causes Coupling
        var battleSlotGUI = eventData?.pointerDrag?.GetComponentInParent<BattleSlotGUI>();
        if (battleSlotGUI != null) {
            battleSlotGUI.IsAttached = false;
            battleSlotGUI.attachedBattleSkillGUI = null;
        }

        transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();
        canvasGroup.blocksRaycasts = false;

        SoundEffectManager.Instance.Play(unslotEffectSound, 0.11f);
    }

    public void OnDrag(PointerEventData eventData){
        rectTransform.position = eventData.position;

        // * This code causes coupling between SkillGUI draging function and Showing Skill Info Funcion
        // StopClickCoroutine();
    }

    public void OnEndDrag(PointerEventData eventData){
        if (transform.parent == canvas.transform){
            transform.SetParent(previousSlot.transform);
            rectTransform.position = previousSlot.GetComponent<RectTransform>().position;
        }
        else{
            SoundEffectManager.Instance.Play(slotEffectSound);
        }

        if (eventData.pointerCurrentRaycast.gameObject == null || 
            !eventData.pointerCurrentRaycast.gameObject.CompareTag("MyBattleSlotGUI"))
        {
            canvasGroup.blocksRaycasts = true;
        }
    }

    // //This code is about showing the info of the skill
    // private bool isClicking = false;
    // private Coroutine clickCoroutine;

    public void OnPointerEnter(PointerEventData eventData){
        //This may causes coupling

        BattleSkillInfoModalManager.Instance.Execute(gameObject);
        // isClicking = true;
        // clickCoroutine = StartCoroutine(StartClick());
    }

    public void OnPointerExit(PointerEventData eventData){
        BattleSkillInfoModalManager.Instance.Close();
    }

    // public void OnPointerUp(PointerEventData enterEvent){
    //     StopClickCoroutine();
    // }

    // public void OnPointerExit(PointerEventData eventData){
    //      StopClickCoroutine();
    // }

    // public void StopClickCoroutine(){
    //     if (clickCoroutine == null)
    //         return;
        
    //     StopCoroutine(clickCoroutine);
    //     isClicking = false;

    //     // * Need to be refactored
    //     BattleSkillInfoModalManager.Instance.Close();
    // }

    // private IEnumerator StartClick(){
    //     yield return new WaitForSeconds(0.3f);

    //     if (isClicking){
    //         BattleSkillInfoModalManager.Instance.Execute(gameObject);
    //     }
    // }
}
