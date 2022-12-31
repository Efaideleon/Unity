using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private int value;
    private Vector3 position;
    private List<Node> neighbors;

    public Node(int value, Vector3 position)
    {
        this.value = value;
        this.position = position;
    }

    public int Value
    {
        get { return value; }
        set { this.value = value; }
    }

    public Vector3 Position
    {
        get { return position; }
    }

    public List<Node> Neighbors
    {
        get { return neighbors; }
        set{ this.neighbors = value; }  
    }

}


