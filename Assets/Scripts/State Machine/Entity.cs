using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemies inherit this
public class Entity : MonoBehaviour
{
    public FSM stateMachine;
    public D_Entity entityData;

    public int facingDirection { get; set; }

    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject enity { get; private set; }

    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    [SerializeField]
    private Transform playerCheck;

    private Vector2 velocityWorkspace; //temp variable for any vector2

    public virtual void Start()
    {
        facingDirection = 1;

        // enity = GameObject.Find("Entity").gameObject;
        enity = this.gameObject;
        rb = enity.GetComponent<Rigidbody2D>();
        anim = enity.GetComponent<Animator>();

        stateMachine = new FSM();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    //set velocity of enemy
    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWorkspace;
    }


    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, enity.transform.right, entityData.wallCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckMinAggroRange()
    {
        return Physics2D.OverlapCircle(playerCheck.position, entityData.minAggrorange, entityData.whatIsPlayer);
        // return Physics2D.Raycast(playerCheck.position, enity.transform.right, entityData.minAggrorange, entityData.whatIsPlayer);
    }

    public virtual bool CheckMaxAggroRange()
    {
        return Physics2D.OverlapCircle(playerCheck.position, entityData.maxAggroRange, entityData.whatIsPlayer);
        // return Physics2D.Raycast(playerCheck.position, enity.transform.right, entityData.maxAggroRange, entityData.whatIsPlayer);
    }

    public virtual void Flip()
    {
        facingDirection *= -1;
        enity.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));
    }
}
