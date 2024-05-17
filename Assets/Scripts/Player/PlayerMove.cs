using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    GroundCheck groundCheck;

    AudioSource grassSound;
    public GameObject grassSoundObj;

    AudioSource roadSound;
    public GameObject roadSoundObj;

    AudioSource houseSound;
    public GameObject houseSoundObj;

    [SerializeField] private string horizontalInputName = "Horizontal";
    [SerializeField] private string verticalInputName = "Vertical";

    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float sprintSpeed = 6f;

    private CharacterController charController;

    private void Awake()
    {
        grassSound = grassSoundObj.GetComponent<AudioSource>();
        grassSoundObj = GameObject.FindWithTag("Grass_SFX");

        charController = GetComponent<CharacterController>();
        grassSound = grassSoundObj.GetComponent<AudioSource>();
        roadSound = roadSoundObj.GetComponent<AudioSource>();
        houseSound = houseSoundObj.GetComponent<AudioSource>();
        groundCheck = GetComponent<GroundCheck>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;     //CharacterController.SimpleMove() applies deltaTime
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = sprintSpeed;
            grassSound.pitch = 1.5f;
            roadSound.pitch = 1.5f;
            houseSound.pitch = 1.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = 3;
            grassSound.pitch = 1f;
            roadSound.pitch = 1f;
            houseSound.pitch = 1f;
        }
        //Enable and disable grass sound 
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && groundCheck.touchingGrass == true)
        {
            grassSound.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || groundCheck.touchingGrass == false)
        {
            grassSound.enabled = false;
        }

        //Enable and disable road sound
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && groundCheck.touchingRoad == true)
        {
            roadSound.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || groundCheck.touchingRoad == false)
        {
            roadSound.enabled = false;
        }

        //Enable and disable house sound
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && groundCheck.touchingHouse == true)
        {
            houseSound.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || groundCheck.touchingHouse == false)
        {
            houseSound.enabled = false;
        }

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        //simple move applies delta time automatically
        charController.SimpleMove(forwardMovement + rightMovement);
    }

}
