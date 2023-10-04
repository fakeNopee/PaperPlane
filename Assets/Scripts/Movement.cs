using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float jumpForce;
    public float jumpCooldown;
    public float ariMultiplier;

    bool readytojump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;


    public Transform orientation;


    //mouse addition
    float horizontalInputMouse;






    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    void Start()
    {
        readytojump = true;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;



        //locks cursor in game window
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        /*
        if (Input.GetAxis("Mouse X") < 0)
        {
            horizontalInputMouseLeft = Input.GetAxis("Mouse X");
            //Code for action on mouse moving left
            print("Mouse moved left");
        }
        if (Input.GetAxis("Mouse X") > 0)
        {*/
            horizontalInputMouse = Input.GetAxis("Mouse X");
            //Code for action on mouse moving right
            print(Time.deltaTime);
        

        if (Input.GetKey(jumpKey) && readytojump)
        {
            readytojump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {


        /*
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInputMouse * 100f;
        */
        rb.AddForce(Vector3.forward * 1f , ForceMode.Force);
        


        transform.Translate(Vector3.right * Time.deltaTime * horizontalInputMouse*25f);
        }
    void Update()
    {
        MyInput();

    }
    private void ResetJump()
    {
        readytojump = true;
    }

private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce * 0.00000002f, ForceMode.Impulse);
    }


}
