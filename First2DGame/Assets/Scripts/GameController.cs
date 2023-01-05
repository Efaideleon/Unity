using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sadefai; 
public class GameController : MonoBehaviour
{
    [SerializeField] private Graph graph;  
    [SerializeField] private Player player;
    string targetNodeName;
    string currentNodeName;
    private float speed = 6;
    private int currentCheckpoint = 0;
    private bool move = true;
    float distanceLeft = 0;
    private List<Vector3> path;
    void Start()
    {
        Dictionary<string, string> nodeNeighbors = new Dictionary<string, string>
        {
            { "A", "BD" },
            { "B", "ACF" },
            { "C", "BH" },
            { "D", "NAI" },
            { "E", "N" }, //revise
            { "F", "NBOK" },
            { "G", "O" },
            { "H", "COM" },
            { "I", "DK" },
            { "J", "N" },
            { "K", "IFM" },
            { "L", "O" },
            { "M", "KH"},
            { "N", "DEFJ"},
            { "O", "FGHL" }
        };

        graph.createGraph(nodeNeighbors);
        currentNodeName = "A";
        player.Position = graph.findNode(currentNodeName).Position;
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
                player.Position = Vector3.MoveTowards(player.Position, (Vector3)path[currentCheckpoint], speed * Time.deltaTime);
                distanceLeft = graph.distance(player.Position, (Vector3)path[currentCheckpoint]);
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
