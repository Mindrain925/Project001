using UnityEngine;

[CreateAssetMenu(fileName = "New Line Data", menuName = "Dialogue/DialogueEventData/LineData")]
public class LineData : DialogueEventData
{
    [SerializeField] private DialogueCharacterData dialogueCharacterData;
    [SerializeField] private string portraitType;
    [SerializeField] private string content;

    public DialogueCharacterData DialogueCharacterData => dialogueCharacterData;
    public string PortraitType => portraitType;
    public string Content => content;

        private void OnEnable()
    {
        type = "Line";
    }
}
