using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Character Data", menuName = "DialogueCharacterData")]
public class DialogueCharacterData : ScriptableObject
{
    [SerializeField] string firstName;
    [SerializeField] string lastName;
    [SerializeField] Sprite idlePortrait;
    [SerializeField] Sprite madPortrait;
    [SerializeField] Sprite sadPortrait;
    [SerializeField] Sprite sighPortrait;
    [SerializeField] Sprite smirkPortrait;
    [SerializeField] AudioClip chatEffectSound;

    public string FirstName => firstName;
    public string LastName => lastName;
    // Method to get a sprite based on a type
    public Sprite GetSprite(string spriteType)
    {
        switch (spriteType)
        {
            case "Idle":
                return idlePortrait;
            case "Mad":
                return madPortrait;
            case "Sad":
                return sadPortrait;
            case "Sigh":
                return sighPortrait;
            case "Smirk":
                return smirkPortrait;
            default:
                Debug.LogError($"Sprite type \"{spriteType}\" not recognized. Returning idlePortrait as default.");
                return idlePortrait;
        }
    }
    public AudioClip ChatEffectSound => chatEffectSound;
}
