using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sadefai; 
public class GameController : MonoBehaviour
{
    [SerializeField] private Graph graph;  
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject customerPrefab;
    private List<GameObject> customerQueue;
    
    void Awake()
    {
        Dictionary<string, string> nodeNeighbors = new Dictionary<string, string>
        {
            { "A", "BD" },
            { "B", "ACF" },
            { "C", "BH" },
            { "D", "NAI" },
            //{ "E", "N" }, //revise
            { "F", "NBOK" },
            //{ "G", "O" },
            { "H", "COM" },
            { "I", "DK" },
            //{ "J", "N" },
            { "K", "IFM" },
            //{ "L", "O" },
            { "M", "KH"},
            { "N", "DF"},
            { "O", "FH" }
        };
        graph.createGraph(nodeNeighbors);
        customerQueue = new List<GameObject>();
    }



    // Update is called once per frame
    void Update()
    {
        if(customerQueue.Count < 5)
        {
            GameObject c = Instantiate(customerPrefab, spawnPoint.transform) as GameObject;
            customerQueue.Add(c);
        }
        
        
    }

    public Graph getGraph()
    {
        return graph;
    }

}
