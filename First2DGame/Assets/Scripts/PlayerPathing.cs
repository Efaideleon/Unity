using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using sadefai; 
public class PlayerPathing : MonoBehaviour
{

    Vector2 target;
    string start;
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

        start = "A";
        graph = new Graph(nodeNeighbors);
        path = graph.createPath(start, "K");
        foreach(Vector3 pos in path)
        {
            print(pos);
        }
        transform.position = graph.getStartingPosition(start);
    }



    // Update is called once per frame
    void FixedUpdate()
    {

        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, (Vector3)path[currentCheckpoint], speed * Time.deltaTime);
            distanceLeft = graph.distance(transform.position, (Vector3)path[currentCheckpoint]);
        }
        if ( distanceLeft == 0)
        {
            currentCheckpoint++;
        }
        if (currentCheckpoint >= path.Count)
        {
            move = false;
        }
        
    }
}
