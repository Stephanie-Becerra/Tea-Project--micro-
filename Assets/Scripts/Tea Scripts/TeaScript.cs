using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaScipt : MonoBehaviour
{
    private int value = 1;
    private Collider2D col;
    private Vector3 startDragPosition;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
