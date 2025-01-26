using System;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Data", menuName = "Dialogue/DialogueData")]
public class DialogueData : ScriptableObject
{
    [SerializeField] List<string> participatorsNames = new List<string>();
    [SerializeField] List<DialogueEventData> events = new List<DialogueEventData>();

    public List<string> ParticipatorsNames => participatorsNames;

    public List<DialogueEventData> Events => events;
}
