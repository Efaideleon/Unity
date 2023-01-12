using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Table : MonoBehaviour
{
    [SerializeField] private GameObject checkpoint; 
    void Start()
    {

    }
    void Update()
    {
        
    }

    public string getNodeName(){
        return checkpoint.name;
    }

}
