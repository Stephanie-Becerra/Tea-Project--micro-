using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackTeaScipt : MonoBehaviour
{
    private int value = 1;
    private Collider2D col;
    private Vector3 startDragPosition;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
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
        transform.position = GetMouseWorldPosition();
    }
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition();
    }
    private void OnMouseUp()
    {
        col.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        col.enabled = true;
        if (hitCollider != null && hitCollider.TryGetComponent(out IdropReact dropArea))
        {
            dropArea.OnObjectDrop(value);
            transform.position = startDragPosition;
        }
        else
        {
            transform.position = startDragPosition;
        }
    }


    




    // Update is called once per frame
    void Update()
    {
        
    }
}
