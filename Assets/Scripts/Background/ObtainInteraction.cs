using UnityEngine;

// 아이템 획득
public class ObtainInteraction : InteractionClick
{
    private void Awake()
    {
        interactionType = "Obtain";
    }

    public override void OnInteractionClick()
    {
        Debug.Log("You have obtained an item!");
    }
}
