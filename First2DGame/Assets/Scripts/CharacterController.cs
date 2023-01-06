using sadefai;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Graph graph;
    private float speed = 6;
    private int currentCheckpoint = 0;
    private bool move = true;
    float distanceLeft = 0;
    private List<Vector3> path;
    string targetNodeName;
    string currentNodeName;
    private bool hasPlate;
    private string counterNodeName;
    private Vector3 s2;
    [Header("Events")]
    [Space]

    public UnityEvent OnFoodDelivered;
    // Start is called before the first frame update
    void Start()
    {
        currentNodeName = "A";
        counterNodeName = "B";
        transform.position = graph.findNode(currentNodeName).Position;
        
    }

    private void FixedUpdate()
    {
        if (transform.position == graph.findNode(counterNodeName).Position) // 'B' is node where plate counter is at
        {
            hasPlate = true;
        }
        if (transform.position == graph.findNode("E").Position)
        {
            hasPlate = false;
            OnFoodDelivered.Invoke();
        }
    }

    public void Move(bool mclick)
    {
        if (mclick && distanceLeft == 0)
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D clickedCollider = Physics2D.OverlapPoint(mouseWorldPosition);
            if (clickedCollider != null)
            {
                targetNodeName = clickedCollider.name;
                path = graph.createPath(currentNodeName, targetNodeName);
                if (path != null)
                {
                    move = true;
                    currentCheckpoint = 0;
                    currentNodeName = targetNodeName;
                }
            }
        }
        if (path != null)
        {
            if (move)
            {
                transform.position = Vector3.MoveTowards(transform.position, (Vector3)path[currentCheckpoint], speed * Time.deltaTime);
                distanceLeft = graph.distance(transform.position, (Vector3)path[currentCheckpoint]);
            }
            if (distanceLeft == 0)
            {
                currentCheckpoint++;
            }
            if (currentCheckpoint >= path.Count)
            {
                move = false;
            }
        }
    }

    public bool HasPlate()
    {
        return hasPlate;
    }

}
