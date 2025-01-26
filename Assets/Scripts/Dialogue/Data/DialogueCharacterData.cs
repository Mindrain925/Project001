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

    public string FirstName => firstName;
    public string LastName => lastName;
    public Sprite IdlePortrait => idlePortrait;
    public Sprite MadPortrait => madPortrait;
    public Sprite SadPortrait => sadPortrait;
    public Sprite SighPortrait => sighPortrait;
    public Sprite SmirkPortrait => smirkPortrait;
}
