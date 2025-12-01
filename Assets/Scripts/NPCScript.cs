using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCScript : MonoBehaviour
{
    private Vector3 startPosition = new Vector3(-13.0f, 2.93f, 0.0f);
    private Vector3 convoStartPosition = new Vector3(0.08f, 2.93f, 0.0f);
    private Vector3 endPosition = new Vector3(13.0f, 2.9f, 0.0f);

    private Vector3 currentPos;
    //public float walkSpeed = 1;

    //array of tea names added for the text to work (hopefully won't cause issues)
    public string[] teaNames = { "Black Tea", "Cinnamin tea" };
    public int[] teaTypes = { 0, 1 };
    public int currentTeaType;

    public NPCType currentNPC;
    private int numNpc;
    private bool endDay;
    [SerializeField] private DialogueController theTextController;
    [SerializeField] private Canvas textCanvas;
    [SerializeField] private SubmitScipt submitScript;
    [SerializeField] private NPCManager npcMang;
    [SerializeField] private EndDayManger endManger;


  
    void Start()
    {
        endDay = false;
        numNpc = 1;
        transform.position = startPosition;
        currentPos = startPosition;
        StartCoroutine(WalkCycleToConvo());
        StartCoroutine(startEndWalk());
    }

    public string AssignRandomTea()
    {
        currentTeaType = Random.Range(0, teaNames.Length);
        return teaNames[currentTeaType];
    }

    public void OnMouseUp()
    {
        Talk(currentNPC.greetingDialogue);
    }

    private IEnumerator WalkCycleToConvo()
    {
        textCanvas.enabled = false;
        print(currentTeaType + "this is the tea type that was assigned");
        while (currentPos.x < convoStartPosition.x)
        {
            currentPos.x = currentPos.x + currentNPC.walkSpeed;
            if (currentPos.x > convoStartPosition.x) 
            {
                currentPos.x = convoStartPosition.x;
                transform.position = currentPos;
            }
            else 
            {
                transform.position = currentPos;
            }
            yield return new WaitForSeconds(0.08f);
            
        }
        textCanvas.enabled = true;

        Talk(currentNPC.greetingDialogue);

    }
    private IEnumerator WalkCycleOut()
    {
        
        while (currentPos.x < endPosition.x) 
        {
            currentPos.x = currentPos.x + currentNPC.walkSpeed;
            transform.position = currentPos;

            yield return new WaitForSeconds(0.08f);
        }
    }

    private IEnumerator startEndWalk()
    {
        yield return new WaitUntil(() => submitScript.isSubmited());
        submitScript.resetEverything();
        Talk(currentNPC.endDialogue);
        yield return StartCoroutine(WalkCycleOut());
        Talk(currentNPC.endDialogue);
        if (!endDay)
        {
            ResetNpc();
        }
        else 
        {
            print("end of the day so if there is a NPC it gliches the thing ight now");
            endManger.theEnd();
        }

    }


    public void Talk(DialogueText npcText) 
    {
        theTextController.DisplayNextParagraph(npcText);
    }

    public void ResetNpc() 
    {
        npcMang.AssignRandomProfile();
        transform.position = startPosition;
        currentPos = startPosition;
        textCanvas.enabled = false;
        StartCoroutine(WalkCycleToConvo());
        StartCoroutine(startEndWalk());
        numNpc++;
        if (numNpc > 2) 
        {
            endDay = true;
        }
    }
    public void SetNewProfile(NPCType chosen)
    {
        currentNPC = chosen;
    }
    public bool isEndDay() 
    {
        return endDay;
    }
    

    
   /* void Update()
    {

    }
   */
}
