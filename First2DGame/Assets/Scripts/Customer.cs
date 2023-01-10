using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DragAndDrop : MonoBehaviour
{
    private bool dragging, placed;
    private Vector2 originalPosition; 
    private Vector2 offset;

    [SerializeField] private Table table1;
    void Awake()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if(placed) return;
        if(!dragging) return;
        var mousePosition = GetMousePos();
        transform.position = mousePosition - offset;

    }

    void OnMouseDown()
    {
        dragging = true;
        offset = GetMousePos() - (Vector2)transform.position;
        print("mouse is down");
    }

    void OnMouseUp()
    {
        if (Vector2.Distance(transform.position, table1.transform.position) < 5) 
        {
            print("placed");
            Vector3 offset = new Vector3(5.0f, 0.0f, 0f);
            transform.position = table1.transform.position - offset;
            print(transform.position);
            print(table1.transform.position);
            placed = true;
        }
        else
        {
            transform.position = originalPosition;
            dragging = false;
        }
    }
    
    Vector2 GetMousePos(){
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
