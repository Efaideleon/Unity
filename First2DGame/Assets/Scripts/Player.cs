using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool hasPlate;

    public bool HasPlate
    {
        get {return hasPlate;}
        set{ hasPlate = value;}
    }
    public Vector3 Position
    {
        get{return transform.position;}
        set{transform.position = value;}
    }
}
