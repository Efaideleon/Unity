using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Customer : MonoBehaviour
{
    private bool dragging, placed, onTopOfTable;
    private Vector2 originalPosition; 
    private Vector2 offset;
    [SerializeField] private Animator animator;
    private GameObject table;
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
        //call an event 
    }

    void OnMouseUp()
    {
        if(onTopOfTable){
            print("placed");
            onSeated();
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

    void onSeated()
    {
        animator.SetBool("isSeated", true);
        Vector3 offset = new Vector3(1.8f, -0.5f, 0f); //use function to compute Vector
        transform.position = table.transform.position - offset;
        this.transform.SetParent(table.transform);
        placed = true;
        this.gameObject.GetComponent<Collider2D>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Table"))
        {
            table = other.gameObject;
            print("on top of table");
            onTopOfTable = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Table"))
        {
            onTopOfTable = false;
            print("out of table");
        }
    }
}
