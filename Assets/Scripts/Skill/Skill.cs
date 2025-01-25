using UnityEngine;

abstract public class Skill : MonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] private SkillData skillData;
    // private Sprite sprite;
    // public Sprite Sprite{
    //     get { return sprite; }
    // }
    // private void Awake() {
    //     sprite = skillData.Icon;
    // }

    public SkillData SkilData => skillData;
    
    // public void Execute(){
    //     Debug.Log("Executed Skill Name : " + skillData.Name);
    //     Debug.Log("Executed Skill Content : " + skillData.Content);
    //     Debug.Log("Executed Skill CoolDown : " + skillData.CoolDown );
    //     Debug.Log("Executed Skill Content : " + skillData.Type);

    //     if (!audioSource.isActiveAndEnabled) {
    //         audioSource.enabled = true; // Enable the AudioSource
    //     }
    //     audioSource.clip = skillData.EffectSound; 
    //     audioSource.Play();
    // }

    virtual public void Execute(){
        Debug.Log("Default Execute called. Skill Name: " + skillData.Name);
    }
    virtual public void Execute(BattleSkill battleSkill){
        Debug.Log("Default Execute(BattleSkill) called.");
    }
    virtual public void Execute(BattleSkill[] battleSkills){
        Debug.Log("Default Execute(BattleSkill[]) called.");
    }
}
