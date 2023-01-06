using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        controller.Move(Input.GetMouseButtonDown(0));
        
        if (controller.HasPlate())
        {
            animator.SetBool("hasFood", true);
        }
    }

    public void onFoodDelivered()
    {
        animator.SetBool("hasFood", false);

    }


}
