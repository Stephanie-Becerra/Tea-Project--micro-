using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SubmitScipt : MonoBehaviour, IdropReact
{

    [SerializeField] private NPCScript theNpc;
    [SerializeField] private DialogueController textControl;
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
                print("Tea Submited");
                print("Submited was black tea " + value);
                submited = true;

            /* check on this code since it causes the teapot to not reset
             * was trying to account for a player not finishing the dialogue tree
             */

            //if (textControl.checkQueue()) 
            //{
              //  textControl.forceEndConvo();
            //}
            //}
           
        }
        else
        {
            print("NO TEA AAAAAAAAAAAAAAAA!");
        }
    }


    public void resetEverything() 
    {
        value = -1;
        submited = false;
    }
    //
    public bool isSubmited() 
    {
        return submited;
    }

}
