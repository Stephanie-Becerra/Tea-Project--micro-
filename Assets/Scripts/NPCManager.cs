using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] private NPCScript currentNPC;
    public NPCType[] allNPCTypes;

    public void AssignRandomProfile()
    {
        NPCType currentNPCType = allNPCTypes[Random.Range(0, allNPCTypes.Length)];
        currentNPC.SetNewProfile(currentNPCType);
    }

}
