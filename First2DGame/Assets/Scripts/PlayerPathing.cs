using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using sadefai; 
public class PlayerPathing : MonoBehaviour
{

    Vector2 target;
    Vector3 checkpoint1;
    Vector3 checkpoint2;
    Vector3 checkpoint3;
    private float speed = 6;
    private int currentCheckpoint = 0;
    private bool move = true;
    [SerializeField] private PathCreator pathcreator;
    float distanceLeft = 0;

    private List<Vector3> p;
    void Start()
    {    
        p = pathcreator.getPath();
        foreach(Vector3 pos in p)
        {
            print(pos);
        }
        transform.position = pathcreator.getStartingNode().Position;
    }



    // Update is called once per frame
    void FixedUpdate()
    {

        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, (Vector3)p[currentCheckpoint], speed * Time.deltaTime);
            distanceLeft = pathcreator.distance(transform.position, (Vector3)p[currentCheckpoint]);
        }
        if ( distanceLeft == 0)
        {
            currentCheckpoint++;
        }
        if (currentCheckpoint >= p.Count)
        {
            move = false;
        }
        
    }
}
