using System.Buffers.Text;
using UnityEngine;

// Base class for all skills
public class SkillData : ScriptableObject
{
    [SerializeField] private string content;
    [SerializeField] private int coolDown;
    [SerializeField] private Sprite icon;
    [SerializeField] private string skillName;
    [SerializeField] protected string skillType;
    [SerializeField] private AudioClip effectSound;

    public string Content => content;
    public int CoolDown => coolDown;
    public Sprite Icon => icon;
    public string Name => skillName;
    public string Type => skillType;
    public AudioClip EffectSound => effectSound;
}

