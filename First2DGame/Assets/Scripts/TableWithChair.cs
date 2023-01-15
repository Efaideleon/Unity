using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sadefai;
public class Table : MonoBehaviour
{
    [SerializeField] private Node checkpoint;
    private Node node;
    void Awake()
    {

    }
    void Update()
    {
        
    }

    public void createCheckPoint(GameController gameController, string name, List<string> neighbors)
    {
        Vector3 position = this.transform.position;
        position.y += 2;
        node = Instantiate(checkpoint, position, Quaternion.identity, this.transform);
        node.name = name; 
        node.Neighbors = neighbors;
        print("Creating Checkpoint for a new Table");
        print("checkpoint name: " + node.name);
        print("checkpoint neighbors: " + node.Neighbors);
        gameController.getGraph().addNodeToGraph(node);
        print("Printing Graph After Adding Checkpoint: " + node.name);
        gameController.getGraph().printNodeList();
    }

    public string getNodeName(){
        print("The name of the node for the table " + node.name);
        return node.name;
    }
}
