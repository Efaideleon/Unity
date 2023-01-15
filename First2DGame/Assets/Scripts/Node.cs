using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private List<string> neighbors;

    public List<string> Neighbors
    {
        get { return neighbors; }
        set { this.neighbors = value; }  
    }
}

