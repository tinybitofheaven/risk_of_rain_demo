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
    public GameObject entity { get; private set; }
    public AnimationToStateMachine atsm { get; private set; }

    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    // [SerializeField]
    // private Transform backCheck;
    [SerializeField]
    private Transform playerCheck;

    private Vector2 velocityWorkspace; //temp variable for any vector2
    public GameObject playerGO;

    private float flipCooldown = 0.2f;
    private float lastFlipTime = -0.2f;

    public float spriteHeight;
    public float spriteWidth;

    public int currHealth;

    public virtual void Start()
    {
        facingDirection = 1;

        entity = this.gameObject;
        rb = entity.GetComponent<Rigidbody2D>();
        anim = entity.GetComponent<Animator>();
        atsm = entity.GetComponent<AnimationToStateMachine>();

        stateMachine = new FSM();
        playerGO = GameObject.FindGameObjectWithTag("Player");
        spriteHeight = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        spriteWidth = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x;

        currHealth = entityData.startingHealth;
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();

        //TODO:REMOVE
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(10);
        }
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
        return Physics2D.Raycast(wallCheck.position, entity.transform.right, entityData.wallCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckMinAggroRange()
    {
        return Physics2D.OverlapCircle(playerCheck.position, entityData.minAggroRange, entityData.whatIsPlayer);
        // return Physics2D.Raycast(playerCheck.position, enity.transform.right, entityData.minAggrorange, entityData.whatIsPlayer);
    }

    public virtual bool CheckMaxAggroRange()
    {
        return Physics2D.OverlapCircle(playerCheck.position, entityData.maxAggroRange, entityData.whatIsPlayer);
        // return Physics2D.Raycast(playerCheck.position, enity.transform.right, entityData.maxAggroRange, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInAttackRange()
    {
        return Physics2D.Raycast(playerCheck.position, playerGO.transform.right, entityData.attackRange, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerIsGrounded()
    {
        return playerGO.GetComponent<PlayerController>().Grounded;
    }

    public virtual void Flip()
    {
        if (Time.time >= lastFlipTime + flipCooldown)
        {
            lastFlipTime = Time.time;
            facingDirection *= -1;
            entity.transform.Rotate(0f, 180f, 0f);
        }
    }
    public virtual void Flip(bool ignoreCD)
    {
        lastFlipTime = Time.time;
        facingDirection *= -1;
        entity.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void SetPosition(Vector2 position)
    {
        entity.transform.position = position;
    }

    public virtual void TakeDamage(int damage)
    {
        currHealth -= damage;
        if (currHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    { }

    public virtual void Destroy()
    {
        // Destroy(this.gameObject);

        Destroy(gameObject.GetComponent<AnimationToStateMachine>());
        // gameObject.GetComponent<SpriteRenderer>().sprite = 
        Destroy(gameObject.GetComponent<Animator>());
        // Destroy(gameObject.GetComponent<BoxCollider2D>());
        gameObject.layer = LayerMask.NameToLayer("DeadEnemy");
        gameObject.tag = "DeadEnemy";
        Destroy(this);
    }

    public virtual void OnDrawGizmos()
    {
        //Vector2 originBack = new Vector2(ledgeCheck.position.x - gameObject.GetComponent<SpriteRenderer>().sprite.rect.width / 2, ledgeCheck.position.y);
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));
        // Gizmos.DrawLine(backCheck.position, backCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));

        // Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(entity.transform.right * entityData.attackRange), 0.1f);
        // Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(entity.transform.right * entityData.minAggroRange), 0.1f);
        // Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(entity.transform.right * entityData.maxAggroRange), 0.1f);
    }
}
