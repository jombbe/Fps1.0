using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float rotateSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        CharacterController characterControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("W"))
        {
            walk();
        }
    }

    public void walk()
    {
        
    }
}
