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
        Dictionary<string, List<string>> nodeNeighbors = new Dictionary<string, List<string>>
        {
            { "1", new List<string>{"2", "8"} },
            { "2", new List<string>{"3", "1", "O"} },
            { "3", new List<string>{"2", "4", "10"} },
            { "4", new List<string>{"3", "5"} },
            { "5", new List<string>{"4", "12"} },
            { "8", new List<string>{"1", "9"} },
            { "9", new List<string>{"8", "10"} },
            { "10", new List<string>{"9", "3", "11"} },
            { "11", new List<string>{"10", "12"} },
            { "12", new List<string>{"5", "11"} },
            { "O", new List<string>{"2"}}
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
