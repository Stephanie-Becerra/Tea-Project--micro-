using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NPCType/New NPC Profile")]

public class NPCType : ScriptableObject
{
    public string npcName;
    public DialogueText greetingDialogue;
    public DialogueText endDialogue;

    //future for tea prefrence add public string[] tea names or have them assigned as 
    //numbers
    public float walkSpeed = 1;
}
//