using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private string name;
    private Vector3 position;
    private string neighbors;

    public Node(string name, Vector3 position, string neighbors )
    {
        this.name = name;
        this.position = position;
        this.neighbors = neighbors;
    }

    public Vector3 Position
    {
        get { return position; }
    }

    public string Neighbors
    {
        get { return neighbors; }
        set { this.neighbors = value; }  
    }

    public string Name
    {
        get { return name; }
    }
}


