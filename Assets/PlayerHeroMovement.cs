using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeroMovement : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    public Vector3 movementInput;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    

    void Update()
    {
        Inputs();
        Animation();
        Rotation();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Inputs()
    {
        movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Move()
    {
        
        Vector3 finalMovement = movementInput.normalized * speed;

        rb.velocity = finalMovement;
    }

    void Rotation()
    {
        if (movementInput.magnitude == 0) return;

        Quaternion targetRotation = Quaternion.identity;

        if (movementInput.magnitude != 0) 
        {
            targetRotation = Quaternion.LookRotation(movementInput.normalized);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void Animation()
    {
        if(rb.velocity.magnitude > 0.1)
        {
            animator.SetBool("running", true);
        }else animator.SetBool("running", false);
    }
}
