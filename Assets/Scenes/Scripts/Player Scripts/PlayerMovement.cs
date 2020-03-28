using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private CharacterController characterController;

    private Vector3 moveDirection;

    public float speed = 5f;
    private float gravity = 20f;

    public float jumpForce = 10f;
    private float verticalVelocity;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }


    void MovePlayer()
    {
        moveDirection = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        ApplyGravity();

        characterController.Move(moveDirection);
    }//move player

    void ApplyGravity()
    {
        verticalVelocity -= gravity * Time.deltaTime;

        PlayerJump(); // jump

        moveDirection.y = verticalVelocity * Time.deltaTime;

    }//applies gravity to player

    void PlayerJump()
    {
        if(characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
        }
    }



}
