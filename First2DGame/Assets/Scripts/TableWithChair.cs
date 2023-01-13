using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sadefai;
public class Table : MonoBehaviour
{
    [SerializeField] private Node checkpoint; 
    void Awake()
    {

    }
    void Update()
    {
        
    }

    public void createCheckPoint(GameController gameController, string name, string neighbors)
    {
        Instantiate(checkpoint, this.transform.position, Quaternion.identity, this.transform);
        checkpoint.name = name; 
        checkpoint.Neighbors = neighbors;
        print("Creating Checkpoint for a new Table");
        print("checkpoint name: " + checkpoint.name);
        print("checkpoint neighbors: " + checkpoint.Neighbors);
        gameController.getGraph().addNodeToGraph(checkpoint);
        print("Printing Graph After Adding Checkpoint: " + checkpoint.name);
        gameController.getGraph().printNodeList();
    }

    public string getNodeName(){
        print("The name of the node for the table " + checkpoint.name);
        return checkpoint.name;
    }
}
