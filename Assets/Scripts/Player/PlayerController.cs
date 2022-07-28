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
    public bool Grounded;
    public LayerMask whatIsGround;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //movement
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        //jump
        Grounded = Physics2D.OverlapCircle(groundPoint.position, 0.2f, whatIsGround);
        if (Input.GetButtonDown("Jump") && Grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //shoot1
        if (Input.GetKey(KeyCode.Q))
        {
            anim.SetTrigger("Shoot1");
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_shoot1"))
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
            }

        }


        //animation 
        anim.SetBool("Grounded", Grounded);
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }
}
