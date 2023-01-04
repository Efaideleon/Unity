using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using sadefai; 
public class PlayerPathing : MonoBehaviour
{

    string targetNodeName;
    string currentNodeName;
    private float speed = 6;
    private int currentCheckpoint = 0;
    private bool move = true;
    [SerializeField] private Graph graph;  
    float distanceLeft = 0;

    private List<Vector3> path;
    void Start()
    {
        Dictionary<string, string> nodeNeighbors = new Dictionary<string, string>
        {
            { "A", "BD" },
            { "B", "ACF" },
            { "C", "BH" },
            { "D", "EAFI" },
            { "E", "DF" }, //revise
            { "F", "EDBHK" },
            { "G", "FH" },
            { "H", "CFM" },
            { "I", "DK" },
            { "J", "DF" },
            { "K", "IFM" },
            { "L", "FH" },
            { "M", "KH"},
        };

        graph.createGraph(nodeNeighbors);
        currentNodeName = "A";
        transform.position = graph.findNode(currentNodeName).Position;
    }



    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0) && distanceLeft == 0)
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D clickedCollider = Physics2D.OverlapPoint(mouseWorldPosition);
            
            if(clickedCollider != null)
            {              
                targetNodeName = clickedCollider.name;
                path = graph.createPath(currentNodeName, targetNodeName);
                if(path != null)
                {
                    move = true;
                    currentCheckpoint = 0;
                    currentNodeName = targetNodeName;     
                }          
            }   
        }

        if(path != null)
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
}
