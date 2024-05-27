using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private GameObject groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GroundCheck())
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        Movement();



        if (rb.velocity.z > 5)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 5);
        }
        else if(rb.velocity.z < -5)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -5);
        }

        if(rb.velocity.x > 5)
        {
            rb.velocity = new Vector3(5, rb.velocity.y, rb.velocity.z);
        }
        else if(rb.velocity.x < -5)
        {
            rb.velocity = new Vector3(-5, rb.velocity.y, rb.velocity.z);
        }
    }

    void Movement()
    {
        float DirectionZ = Input.GetAxisRaw("Vertical");
        float DirectionX = Input.GetAxisRaw("Horizontal");

        if (DirectionZ == 1)
        {
            rb.AddForce(new Vector3(0, 0, 5), ForceMode.Impulse);
        }
        else if (DirectionZ == -1)
        {
            rb.AddForce(new Vector3(0, 0, -5), ForceMode.Impulse);
        }

        switch (DirectionX)
        {
            case 1:
                rb.AddForce(new Vector3(5,0,0), ForceMode.Impulse);
                break;
            case -1:
                rb.AddForce(-5,0,0, ForceMode.Impulse);
                break;
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);

        }
    }

    private bool GroundCheck()
    {
        return Physics.CheckBox(groundCheck.transform.position, new Vector3(1f, 0.2f, 1), groundCheck.transform.rotation, groundMask);

    }
}
