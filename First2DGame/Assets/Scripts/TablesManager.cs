using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TablesManager : MonoBehaviour
{
    [SerializeField] private Table tablePrefab;
    [SerializeField] private GameController gameController;
    [SerializeField] private Tilemap tableTilemap;
    [SerializeField] private Tilemap checkpointsTilemap;
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
        listOfPositions.Add(new Vector3(-0.5f,-0.5f, 0));
        listOfPositions.Add(new Vector3(7.5f,-0.5f, 0));
        listOfPositions.Add(new Vector3(-0.5f,-7.5f, 0));
        listOfPositions.Add(new Vector3(7.5f,-7.5f, 0));
        //listOfPositions.Add(new Vector3(-5.57f,3.66f, 0));
        //listOfPositions.Add(new Vector3(-5.57f,3.66f, 0));
        listOfTables = new List<Table>();

        string [] tableNodeNames = {"6", "7", "13", "14"};
  
        List<string> neighbors = new List<string>(){ "2", "4", "9", "11"};
        for(int i = 0; i < numOfTablesAtStart; i++)
        {
            
            Table table = Instantiate(tablePrefab, listOfPositions[i], Quaternion.identity, this.transform);

            table.createCheckPoint(gameController, tableNodeNames[i], new List<string>{neighbors[i]} );
            listOfTables.Add(table);
        } 

        foreach(Table table in listOfTables)
        {
            print(table.getNodeName()+ "table hashcode :p = " + table.GetHashCode());
            print(table.transform.position);
        }
    }
}
