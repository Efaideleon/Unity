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


    [SerializeField] private PathCreator pathcreator;
    // Start is called before the first frame update


    void Awake()
    {
     
        Vector3 squareposition = pathcreator.getPositionOfCheckpoint();
        transform.position = squareposition;
        print(squareposition);
    }



    // Update is called once per frame
    void Update()
    {
      
    }
}
