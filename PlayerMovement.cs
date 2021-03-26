using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public LayerMask ground;

    public bool grounded;


    public Transform groundPos;
    public float moveSpeed;
    public float jumpForce;
    public float radious;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //input
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed;
        //moving player
        Vector3 pos = transform.right * x + transform.forward * y;
        Vector3 newPos = new Vector3(pos.x, rb.velocity.y, pos.z);

        rb.velocity = newPos;
        //jumping
        grounded = Physics.CheckSphere(new Vector3(groundPos.transform.position.x, groundPos.transform.position.y, groundPos.transform.position.z), radious, ground);
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
        //sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 12;
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 6;
        }




    }
}
