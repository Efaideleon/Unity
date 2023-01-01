using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using sadefai; 
public class PlayerPathing : MonoBehaviour
{

    string target;
    string lastNode;
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
            { "C", "BFH" },
            { "D", "AFI" },
            { "E", "DF" }, //revise
            { "F", "DBHK" },
            { "G", "FH" },
            { "H", "CFM" },
            { "I", "DK" },
            { "J", "DF" },
            { "K", "IFM" },
            { "L", "FH" },
            { "M", "KH"},
        };

        graph.createGraph(nodeNeighbors);
        lastNode = "A";
        target = "A";
        transform.position = graph.findNode(lastNode).Position;
        path = graph.createPath(lastNode, target);
    }



    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetMouseButtonDown(0))
        {
            lastNode = target;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D clickedCollider = Physics2D.OverlapPoint(mouseWorldPosition);
            target = clickedCollider.name;
            print(target);
            path = graph.createPath(lastNode, target);
            move = true;
            currentCheckpoint = 0;
        }


        if(path.Count > 1)
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
