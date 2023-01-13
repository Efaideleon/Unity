using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sadefai;
public class Table : MonoBehaviour
{
    [SerializeField] private GameObject checkpoint; 
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
        print(checkpoint.name);
        gameController.getGraph().printNodeList();

        gameController.getGraph().addNodeToGraph(name, new Vector3(-8.55f, 1.15f, 0f), neighbors);
    }

    public string getNodeName(){
        print("The name of the node for the table " + checkpoint.name);
        return checkpoint.name;
    }
}
