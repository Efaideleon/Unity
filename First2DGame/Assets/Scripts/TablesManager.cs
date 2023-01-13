using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablesManager : MonoBehaviour
{
    [SerializeField] private Table tablePrefab;
    [SerializeField] private GameController gameController;
    private int numOfTablesAtStart = 4;
    private List<Table> listOfTables;
    private List<Vector3> listOfPositions;
    void Start()    //spawn tables
    {
        SpawnTables();
    }

    void Update()
    {
        
    }

    void SpawnTables()
    {
        listOfPositions = new List<Vector3>();
        listOfPositions.Add(new Vector3(-5.57f,3.66f, 0));
        listOfPositions.Add(new Vector3(5.23f,3.25f, 0));
        listOfPositions.Add(new Vector3(-5.09f,-7.18f, 0));
        listOfPositions.Add(new Vector3(5.72f,-7.47f, 0));
        //listOfPositions.Add(new Vector3(-5.57f,3.66f, 0));
        //listOfPositions.Add(new Vector3(-5.57f,3.66f, 0));
        listOfTables = new List<Table>();

        string [] tableNodeNames = {"W", "X", "Y", "Z"};
        string [] neighbors = { "O", "N", "O", "N"};    
        for(int i = 0; i < numOfTablesAtStart; i++)
        {
            
            Table table = Instantiate(tablePrefab, listOfPositions[i], Quaternion.identity, this.transform);
            table.createCheckPoint(gameController, tableNodeNames[i], neighbors[i]);
            listOfTables.Add(table);
        } 

        foreach(Table table in listOfTables)
        {
            print(table.getNodeName()+ "table hashcode :p = " + table.GetHashCode());
            print(table.transform.position);
        }

        gameController.getGraph().printNodeList();
            print("-------------------------");
    }
}
