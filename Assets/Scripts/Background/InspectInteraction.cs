using UnityEngine;

// 조사
public class InspectInteraction : InteractionClick
{
    private void Awake()
    {
        interactionType = "Inspect";
    }

    public override void OnInteractionClick()
    {
        Debug.Log("You inspect the object closely.");
    }
}
