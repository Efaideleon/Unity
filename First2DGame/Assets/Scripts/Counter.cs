using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private Node checkpoint;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public string getCheckPointName()
    {
        print("clicked on counter");
        return checkpoint.name;
    }
}
