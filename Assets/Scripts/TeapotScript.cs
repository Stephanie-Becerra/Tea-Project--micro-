using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;


public class TeapotScript : MonoBehaviour, IdropReact
{
    private int value = -1;
    private Collider2D col;
    private Vector3 startDragPosition;


    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    public void OnObjectDrop(int values)
    {
        if (values != value)
        {
            value = values;


            //Remeber to remove this PLEASE 
            print("Tea recieved");
            print("hello black tea " + value);
        }
        else if (value != -1 && values != value) 
        {
            value += values;
        }
        else
        {

            /*Remeber to remove this or make a more meta text if 
             * this somehow ever happens
            */
            print("NO TEA AAAAAAAAAAAAAAAA!");
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
            col.enabled = true;
            if (hitCollider != null && hitCollider.TryGetComponent(out IdropReact dropArea))
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
