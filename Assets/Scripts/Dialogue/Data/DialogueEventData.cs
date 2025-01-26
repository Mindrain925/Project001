using UnityEngine;

public class DialogueEventData : ScriptableObject
{
    [SerializeField] protected string type;

    public string Type => type;
}
