using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    public DialogueData dialogueData;
    void Start()
    {
        DialogueManager.Instance.StartDialouge(dialogueData);
    }

}
