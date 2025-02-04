using UnityEngine;

// 이동
public class MoveInteraction : InteractionClick
{
    private void Awake()
    {
        interactionType = "Move";
    }

    public override void OnInteractionClick()
    {
        Debug.Log("You move the object.");
    }
}
