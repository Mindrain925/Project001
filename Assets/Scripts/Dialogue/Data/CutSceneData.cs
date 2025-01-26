using UnityEngine;

[CreateAssetMenu(fileName = "New Cut Scene Data", menuName = "Dialogue/DialogueEventData/CutSceneData")]
public class CutSceneData : DialogueEventData
{
    [SerializeField] private Sprite cutSceneSprite;
    public Sprite CutSceneSprite => cutSceneSprite;
    
    private void OnEnable()
    {
        type = "CutScene";
    }
}
