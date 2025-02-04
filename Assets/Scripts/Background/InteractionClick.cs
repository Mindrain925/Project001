using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 상호작용 객체의 기본 클래스
public abstract class InteractionClick : MonoBehaviour, IPointerClickHandler
{
    // 여러 개의 상호작용 타입을 저장
    // 굳이 리스트로 저장할 필요가 있을까
    protected string interactionType;
    [SerializeField] public bool isLocked = false;
    

    // 클릭 시 실행될 추상 메서드
    public abstract void OnInteractionClick();

    // // 특정 타입의 상호작용을 포함하는지 확인
    // public bool HasInteractionType(string type)
    // {
    //     return interactionType.Contains(type);
    // }

    // IPointerClickHandler 인터페이스 구현
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isLocked)
        {
            Debug.Log("This object is locked.");
            return;
        }
        else
        {
            // 클릭하면 OnInteractionClick() 실행
            OnInteractionClick();
            Debug.Log("Interaction Type: " + interactionType);
        }
        
    }
}

