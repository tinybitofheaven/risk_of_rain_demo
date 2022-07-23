using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player initial attributes
    public Rigidbody2D rb;
    public float moveSpeed;
    public float jumpForce;

    public Transform groundPoint;
    private bool Grounded;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);

        //jump
        Grounded = Physics2D.OverlapCircle(groundPoint.position, 0.2f, whatIsGround);
        if(Input.GetButtonDown("Jump") && Grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
