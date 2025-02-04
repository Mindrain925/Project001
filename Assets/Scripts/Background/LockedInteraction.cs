using UnityEngine;

// 잠긴 상태
public class LockedInteraction : InteractionClick
{
    private void Awake()
    {
        interactionType = "Locked";
    }

    public override void OnInteractionClick()
    {
        Debug.Log("This object is locked.");
    }
}
