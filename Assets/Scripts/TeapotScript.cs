using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

//
public class TeapotScript : MonoBehaviour, IdropReact
{
    private int value = -1;
    private Collider2D col;
    private Vector3 startDragPosition;
    [SerializeField] private TeaManger teaManager;

    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    public void OnObjectDrop(int values)
    {
        if (value == -1)
        {
            value = values;
            teaManager.setCurrentTeaInPot(value);

            //Remeber to remove this PLEASE 
            print("Tea recieved");
            print("hello black tea " + value);
        }
        else if (value != -1 && values != value) 
        {
            int oldValue = value;
            value = teaManager.combineVals(values, value);
            if (oldValue == value) 
            {
                print("but nothing happened (the tea wasn't able to combine)");
            }
            else 
            { 
                teaManager.setCurrentTeaInPot(value);
                print("THE TEA COMBINED AND IT HAS A VALUE OF: " + value);
            }

        }
        else
        {

            /*Remeber to remove this or make a more meta text if 
             * this somehow ever happens
            */
            print("THE FORBIDEN TEXT AAAAAAAAA (how did you get in here)!");
        }
    }


    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0f;
        return mouse;
    }

    // Mouse Functions 
    private void OnMouseDown()
    {
        startDragPosition = transform.position;
        if (value != -1)
        {
            //startDragPosition = transform.position;
            transform.position = GetMouseWorldPosition();
        }
        
    }
    private void OnMouseDrag()
    {
        if (value != -1)
        {
            transform.position = GetMouseWorldPosition();
        }
       
    }
    private void OnMouseUp()
    {
        if (value != -1) { 
            col.enabled = false;
            Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
           // GameObject theTrigger = hitCollider.gameObject;
            col.enabled = true;
            if (hitCollider != null && hitCollider.gameObject.tag == "Submit"
                && hitCollider.TryGetComponent(out IdropReact dropArea))
            {
                dropArea.OnObjectDrop(value);
                transform.position = startDragPosition;
                value = -1;

                //Remeber to remove this PLEASE 
                print("Teapot now has nothing");
            }
            else
            {
                transform.position = startDragPosition;
            }
        }
    }








    void Update()
    {
        
    }
}
