using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SubmitScipt : MonoBehaviour, IdropReact
{

    [SerializeField] private NPCScript theNpc;
    [SerializeField] private DialogueController textControl;
    [SerializeField] private TeaManger theTeaInPot;
    private int value = -1;
    private bool submited = false;
   
    void Start()
    {
         
    }

    public void OnObjectDrop(int values)
    {
        if (values != value)
        {
            value = values;

            //if (value == theNpc.teatype)
            //{
            //Remeber to remove this PLEASE 
            if (theNpc.currentTeaType == values)
            {

                print("Tea Submited");
                print("Submited was black tea " + value);
                submited = true;
            }
            else
            {
                if (!textControl.checkEmptyQueue())
                {
                    textControl.forceEndConvo();
                }
                theNpc.Talk(theNpc.currentNPC.wrongTeaDialogue);
                print("Incorrect Tea please try again");
            }

            /* check on this code since it causes the teapot to not reset
             * was trying to account for a player not finishing the dialogue tree
             */

            //if (textControl.checkQueue()) 
            //{
            //  textControl.forceEndConvo();
            //}
            //}

        }
        else if (value != -1 && value == values) 
        {
            if (theNpc.currentTeaType == values)
            {

                print("Tea Submited");
                print("Submited was black tea " + value);
                submited = true;
            }
            else
            {
                if (!textControl.checkEmptyQueue())
                {
                    textControl.forceEndConvo();
                }
                theNpc.Talk(theNpc.currentNPC.wrongTeaDialogue);
                print("Incorrect Tea please try again");
            }
        }
        else
        {
            print("NO TEA AAAAAAAAAAAAAAAA!");
        }
    }


    public void resetEverything() 
    {
        value = -1;

        if (!textControl.checkEmptyQueue()) 
        {
            textControl.forceEndConvo();
        }

        submited = false;
    }
    //
    public bool isSubmited() 
    {
        return submited;
    }

}
