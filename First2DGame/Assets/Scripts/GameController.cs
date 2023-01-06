using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sadefai; 
public class GameController : MonoBehaviour
{
    [SerializeField] private Graph graph;  

    void Awake()
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
    }



    // Update is called once per frame
    void Update()
    {
        
        
    }
}
