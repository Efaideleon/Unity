using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target;
    public AIPath aiPath;

    private void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0 ))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

}
