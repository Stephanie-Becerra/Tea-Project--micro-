using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NPCNameText;
    [SerializeField] private TextMeshProUGUI NPCDialogueText;
    [SerializeField] private NPCScript currentNPC;
    

   private Queue<string> qParagraphs = new Queue<string>();

    private string p;

    private bool endedConvo = false;


    private bool isTypeing;
    [SerializeField] private float typeingSpeed = 10;
    private Coroutine typeDiologueCorutine;



    public void DisplayNextParagraph(DialogueText npcText)
    {
        //when nothing is in the queue
        if(qParagraphs.Count == 0) 
        {
            if (!endedConvo) 
            {
                startConvo(npcText);
            }
            else 
            {
                endConvo();
                return;
            }
        }

        //when there is something in the queue
        p = qParagraphs.Dequeue();

        NPCDialogueText.text = p;
        if (qParagraphs.Count == 0)
        {
            endedConvo = true;
            
        }
    }

    private void startConvo(DialogueText npcText) 
    {
        if (!gameObject.activeSelf) 
        {
            gameObject.SetActive(true);

        }

        NPCNameText.text = npcText.npcName;
        string teaName = currentNPC.AssignRandomTea();

        //has the change where it checks the array for any placeholder text to change 
        //then adds to the queue after the change has happened
        foreach (string paragraph in npcText.paragraphs)
        {
            string changed = paragraph.Replace("{teaType}", teaName);
            qParagraphs.Enqueue(changed);
        }

        /*for (int i = 0; i < npcText.paragraphs.Length; i++)
        {
            qParagraphs.Enqueue(npcText.paragraphs[i]);
        }*/
    }

    private void endConvo() 
    {
        qParagraphs.Clear();
        endedConvo = false;
        if (gameObject.activeSelf) 
        {
            gameObject.SetActive(false);
        }
    }


    //to clear the queue if player didn't click to the end of the dialogue
    public bool checkQueue()
    {
        if (qParagraphs.Count == 0 && !endedConvo)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
    public void forceEndConvo() 
    {
        qParagraphs.Clear();
        endedConvo = false;
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }

    
}
