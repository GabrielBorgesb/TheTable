using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Stats
    [SerializeField] private float moveSpeed;
    public bool canMove;

    //Getters
    private CharacterController characterController;
    private PlayerInputController inputController;

    [SerializeField] Transform fpCamera;

    private void Awake()
    {
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
        inputController = GetComponent<PlayerInputController>();
        fpCamera = Camera.main.transform;
        canMove = true;
    }

    void Update()
    {
        Move();
        SetRotationFromCamera();
    }
    

    void Move()
    {
        if (!canMove) return;

        Vector3 moveDirection = transform.forward * inputController.movementInput.z + transform.right * inputController.movementInput.x;
        moveDirection.y = 0f;


        characterController.Move(moveDirection * Time.deltaTime);

        
    }

    void SetRotationFromCamera()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, fpCamera.eulerAngles.y, transform.eulerAngles.z);

    }
}
