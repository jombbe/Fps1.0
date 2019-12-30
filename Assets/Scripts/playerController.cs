using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class playerController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float Gravity = -9.81f;
    public float jumpHeight = 3.0f;
    float previousHorizontalValue = 0;
    float previousVerticalValue = 0;

    public CharacterController characterController;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Animator handAnim;

    Vector3 velocity;
    bool isGrounded;

    public void Start()
    {
        handAnim = GameObject.Find("Hand").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * Gravity);
        }

        velocity.y += Gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);


        if (x != previousHorizontalValue || z != previousVerticalValue)
        {
            previousHorizontalValue = x;
            previousVerticalValue = z;

            handAnim.SetBool("Walk", true);    
        }
        else
        {
            
        }


    }
}
