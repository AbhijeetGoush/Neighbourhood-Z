using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName = "Horizontal";
    [SerializeField] private string verticalInputName = "Vertical";

    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private float sprintSpeed = 4f;

    private CharacterController charController;


    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;     //CharacterController.SimpleMove() applies deltaTime
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = 4;
            print("Sprinting");
        }
        else
        {
            movementSpeed = 2;
        }

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        //simple move applies delta time automatically
        charController.SimpleMove(forwardMovement + rightMovement);
    }
}
