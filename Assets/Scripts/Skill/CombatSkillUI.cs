using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CombatSkillUI : MonoBehaviour
{
    private Image image;
    private AudioSource audioSource;
    [SerializeField] GameObject skillPrefab;
    private Skill equipedSkill;

    private void Awake() {
        image = GetComponent<Image>();
        equipedSkill = skillPrefab.GetComponent<Skill>();
        audioSource = GetComponent<AudioSource>();
    }

    private void UpdateState()
    {
        if (equipedSkill != null) // Ensure the equipped skill is assigned
        {
            image.sprite = equipedSkill.SkilData.Icon; // Assign the sprite from the skill's Icon property
        }
    }
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)){
            equipedSkill = skillPrefab.GetComponent<Skill>();
            UpdateState();
            equipedSkill.Execute();
        }
    }
}
