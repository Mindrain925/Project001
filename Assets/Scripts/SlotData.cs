using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "New Slot Data", menuName = "SlotData")]
public class SlotData : ScriptableObject
{
    [SerializeField] private int atk;
    [SerializeField] private int def;
    [SerializeField] private int hp;
    [SerializeField] private int speed;

    public int ATK => atk;
    public int DEF => def;
    public int HP => hp;
    public int Speed => speed;
}
