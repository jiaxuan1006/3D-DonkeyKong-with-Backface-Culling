using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_3D : MonoBehaviour
{
    public float moveSpeed = 5f;            // Movement speed of the character
    public float turnSpeed = 10f;           // Rotation speed of the character
    public Transform cameraTransform;

    private Animator animator;
    private Rigidbody rigidbody1;
    private Vector3 moveDirection;
    private string onAir = "n";
    private int WalkStateHash;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody1 = GetComponent<Rigidbody>();

        // Get the hash of the idle state
        WalkStateHash = Animator.StringToHash("Base Layer.Walk");
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the move direction relative to the camera
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();
        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0f;
        cameraRight.Normalize();

        moveDirection = cameraForward * verticalInput + cameraRight * horizontalInput;
        moveDirection.Normalize();

        // Move the character
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
        rigidbody1.MovePosition(transform.position + movement);

        // Rotate the character towards the movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime);

            // Check if the character is in the idle state
            bool isWalk = animator.GetCurrentAnimatorStateInfo(0).fullPathHash == WalkStateHash;

            if(  (onAir == "n") )
            {
                GetComponent<Animator>().Play("Walk");
    
            }

        }

        // Update the animator parameters
        animator.SetFloat("Speed", moveDirection.magnitude);

        //Jump
        if (onAir == "n" && Input.GetKeyDown("space"))
        {
             GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 10, 0);
             GetComponent<Animator>().Play("Jump");
             onAir = "y";
        }

        if( onAir == "n")
        {
           // GetComponent<Animator>().Play("Walk");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="girder")
        {
            onAir = "n";
        }
    }
}
