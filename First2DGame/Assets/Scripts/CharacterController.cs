using sadefai;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Graph graph;
    [SerializeField] private float speed = 12;
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
        currentNodeName = "1";
        counterNodeName = "O";
        transform.position = graph.findNode(currentNodeName).transform.position;
    }

    private void FixedUpdate()
    {
        if (transform.position == graph.findNode(counterNodeName).transform.position)
        {
            hasPlate = true;
        }
        else if (graph.findNode(targetNodeName) != null)
        {
            if (transform.position == graph.findNode(targetNodeName).transform.position)
            {
                hasPlate = false;
                OnFoodDelivered.Invoke();
            }
        }
    }

    public void Move(bool mclick) //move where you click
    {
        if (mclick && distanceLeft == 0)
        {
            Collider2D clickedCollider = getClickedCollider(Input.mousePosition);
            if (clickedCollider != null)
            {
                targetNodeName = getTargetNodeName(clickedCollider);
                path = graph.createPath(currentNodeName, targetNodeName);
                if (path != null)
                {
                    move = true;
                    currentCheckpoint = 0;
                    currentNodeName = targetNodeName;
                }
            }
        }
        traversePath(path);
    }
    public Collider2D getClickedCollider(Vector3 mousePosition)
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return Physics2D.OverlapPoint(mouseWorldPosition);
    }

    public string getTargetNodeName(Collider2D clickedCollider)
    {
        if (clickedCollider.tag == "Table")
        {
            print("you clicked on a table");
            return clickedCollider.gameObject.GetComponent<Table>().getNodeName();
        }
        else if (clickedCollider.tag == "Counter")
        {
            return clickedCollider.gameObject.GetComponent<Counter>().getCheckPointName();
        }
        else 
        {
            return null;
        }
    }

    public void traversePath(List<Vector3> path)
    {
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
