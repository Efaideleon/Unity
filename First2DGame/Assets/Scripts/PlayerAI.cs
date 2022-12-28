using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class PlayerAI : MonoBehaviour
{

    //public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    private Vector3 clickPosition;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        
        clickPosition = transform.position;
        UpdatePath();
        print("hi");
        Debug.Log("efai");
        
        //InvokeRepeating("UpdatePath", 0f, .5f);
        
    }

    void UpdatePath()
    {
        if (transform.position != clickPosition)
        {
            if (seeker.IsDone())
            {
                seeker.StartPath(transform.position, clickPosition, OnPathComplete);
            }
        }
        
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
            //for (int i = 0; i < path.vectorPath.Count; i++)
            //{
               // print("apth: " + Convert.ToString(path.vectorPath[i]));
            //}
            
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = transform.position.z;
            currentWaypoint = 0;
            //print("clicked");
            UpdatePath();
        }

        if (path == null)
        {
            print("chicken");
            return;
        }


        //    return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;

            //return;
        }
        else
        {
            
            transform.position = Vector3.MoveTowards(transform.position, (Vector3)path.vectorPath[currentWaypoint], speed * Time.deltaTime);
            print("currentWaypoint: " + currentWaypoint);
            print("path count" + path.vectorPath.Count);
            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);

            if (distance == 0 && !reachedEndOfPath)
            {
                currentWaypoint++;
            }
            reachedEndOfPath = false;
        }



        


  





        
    




        /*
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        */



    }
}
