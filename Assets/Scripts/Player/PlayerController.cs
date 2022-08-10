using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player initial attributes
    public Rigidbody2D rb;
    public Collider2D _collider;
    public float moveSpeed;
    public float jumpForce;
    private bool die;
    

    //shoot1
    public int shoot1Damage;
    public float shoot1CD = 0.2f;
    private float shoot1Counter;
    public bool shoot1Launch;
    public float Shoot1Counter { get => shoot1Counter; }


    //shoot2
    public float shoot2CD = 3f;
    [HideInInspector] public float shoot2Counter;
    public bool shoot2Launch;
    public int shoot2Damage;
    public float Shoot2Counter { get => shoot2Counter; }

    //shoot3
    public float rollSpeed, rollTime;
    private float rollCounter;
    public bool rolling = false;
    public float shoot3CD = 4f;
    private float shoot3Counter;
    public bool shoot3Launch;
    public float Shoot3Counter { get => shoot3Counter; }

    //shoot4
    public float shoot4CD = 5f;
    private float shoot4Counter;
    public bool shoot4Launch;
    public int shoot4Damage;
    public float Shoot4Counter { get => shoot4Counter; }

    public Transform groundPoint;
    public Transform firePoint;
    public bool Grounded;
    public LayerMask whatIsGround;
    public LayerMask whatIsEnemy;

    public Animator anim;
    private bool isShooting;

    //climbing 
    bool climb = false;
    bool canClimb = false;

    //screenshake
    private CameraMovement shake;


    // Start is called before the first frame update
    void Start()
    {
        die = false;
        shoot1Counter = shoot1CD;
        shoot2Counter = shoot2CD;
        shoot3Counter = shoot3CD;
        shoot4Counter = shoot4CD;
        shake = FindObjectOfType<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        
            //climbing

        if (canClimb)
        {

            if (climb)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                rb.velocity = new Vector2(0f, 0f);
                _collider.isTrigger = true;
                rb.gravityScale = 0;

                if (Input.GetKey(KeyCode.UpArrow))
                {

                    rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);


                }
                if (Input.GetKey(KeyCode.DownArrow))
                {

                    rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);


                }


            }
            else
            {
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.gravityScale = 5;
                _collider.isTrigger = false;

                if (Input.GetKey(KeyCode.UpArrow))
                {

                    climb = true;


                }
                if (Input.GetKey(KeyCode.DownArrow))
                {

                    climb = true;


                }


            }

        }
        else
        {
            climb = false;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = 5;
            _collider.isTrigger = false;
        }


        //rolling
        if (Input.GetKeyDown(KeyCode.C) && shoot3Counter == shoot3CD && !climb)
        {
            rollCounter = rollTime;
            shoot3Launch = true;


        }
        if (rollCounter > 0)
        {
            rolling = true;
            anim.SetBool("Shoot3", rolling);
            Physics2D.IgnoreLayerCollision(10, 11, true);
            rollCounter -= Time.deltaTime;
            rb.velocity = new Vector2(rollSpeed * transform.localScale.x, 0f);
        }
        else
        {

            rolling = false;
            Physics2D.IgnoreLayerCollision(10, 11, false);
            anim.SetBool("Shoot3", rolling);


            //movement
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);

            if (rb.velocity.x < 0 && !isShooting )
            {
                transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);


            }
            else if (rb.velocity.x > 0 && !isShooting)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
        }

        if (shoot3Launch)
        {
            shoot3Counter -= Time.deltaTime;
            if (shoot3Counter < 0)
            {
                shoot3Counter = shoot3CD;
                shoot3Launch = false;
            }
        }



        //jump
        Grounded = Physics2D.OverlapCircle(groundPoint.position, 0.02f, whatIsGround);
        if (Input.GetButtonDown("Jump") && (Grounded || climb))
        {


            if (canClimb)
            {
                if (climb)
                {
                    climb = false;
                }
                
            }
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


        //shoot1
        if ((Input.GetKey(KeyCode.Z) && shoot1Counter == shoot1CD) && !(Input.GetKeyDown(KeyCode.E) && shoot3Counter == shoot3CD &&!climb))
        {
            shoot1Launch = true;
            anim.SetTrigger("Shoot1");
            Invoke("Shoot1", 0.05f);
            Invoke("Shoot1", 0.15f);
            // Shoot1();
        }
        //shoot2
        else if (Input.GetKeyDown(KeyCode.X) && shoot2Counter == shoot2CD && !climb)
        {
            //shake.TriggerShake();
            shoot2Launch = true;
            anim.SetTrigger("Shoot2");

            Shoot2();
        }
        //shoot4
        else if (Input.GetKeyDown(KeyCode.V) && shoot4Counter == shoot4CD && !climb)
        {
            shoot4Launch = true;
            anim.SetTrigger("Shoot4");

            // Shoot4();
            for (int i = 0; i < 6; i++)
            {
                Invoke("Shoot4", 0.05f + 0.1f * i);
            }
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_shoot1"))
        {
            isShooting = true;
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        else
        {
            isShooting = false;
        }

        if (shoot1Launch)
        {
            shoot1Counter -= Time.deltaTime;

            if (shoot1Counter <= 0)
            {
                shoot1Counter = shoot1CD;
                shoot1Launch = false;
            }
        }




        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_shoot2"))
        {
            isShooting = true;
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        else
        {
            isShooting = false;
        }
        if (shoot2Launch)
        {
            shoot2Counter -= Time.deltaTime;
            if (shoot2Counter < 0)
            {
                shoot2Counter = shoot2CD;
                shoot2Launch = false;
            }

        }


        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_shoot4"))
        {
            isShooting = true;
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        else
        {
            isShooting = false;
        }
        if (shoot4Launch)
        {
            shoot4Counter -= Time.deltaTime;
            if (shoot4Counter < 0)
            {
                shoot4Counter = shoot4CD;
                shoot4Launch = false;
            }

        }



        //animation 
        anim.SetBool("Grounded", Grounded);
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Climb", climb);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundPoint.position, 0.02f);
    }

    public void TakeDamage(int damage)
    {
        GameManager.FindInstance().health -= damage;
        if (GameManager.FindInstance().health <= 0)
        {
            
            Die();
        }
    }

    public void Die()
    {
        die = true;
        anim.SetBool("Die", die);
        
    }

    public void Shoot1()
    {
        if (transform.localScale.x > 0)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, Mathf.Infinity, whatIsEnemy);
            if (hitInfo)
            {
                //TODO
                //add explosion
                //update healthbar

                hitInfo.transform.gameObject.GetComponent<Entity>().TakeDamage(shoot1Damage);
                GameManager.FindInstance().SpawnDamageNumber(shoot1Damage, hitInfo);
            }

        }
        else if (transform.localScale.x < 0)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right * -1, Mathf.Infinity, LayerMask.GetMask("Enemy"));
            if (hitInfo)
            {
                //TODO
                //add explosion
                //update healthbar

                hitInfo.transform.gameObject.GetComponent<Entity>().TakeDamage(shoot1Damage);
                GameManager.FindInstance().SpawnDamageNumber(shoot1Damage, hitInfo);
            }
        }

    }

    public void Shoot2()
    {
        if (transform.localScale.x > 0)
        {
            //TODO
            //add explosion
            //update healthbar
            RaycastHit2D[] hits = Physics2D.RaycastAll(firePoint.position, firePoint.right, Mathf.Infinity, LayerMask.GetMask("Enemy"));
            foreach (RaycastHit2D hit in hits)
            {
                hit.transform.gameObject.GetComponent<Entity>().TakeDamage(shoot2Damage);
                hit.transform.gameObject.GetComponent<Entity>().Knockback(Vector2.right);
                GameManager.FindInstance().SpawnDamageNumber(shoot2Damage, hit);
                shake.TriggerShake();
            }
        }
        else if (transform.localScale.x < 0)
        {
            //TODO
            //add explosion
            //update healthbar
            RaycastHit2D[] hits = Physics2D.RaycastAll(firePoint.position, firePoint.right * -1, Mathf.Infinity, LayerMask.GetMask("Enemy"));
            foreach (RaycastHit2D hit in hits)
            {
                hit.transform.gameObject.GetComponent<Entity>().TakeDamage(shoot2Damage);
                hit.transform.gameObject.GetComponent<Entity>().Knockback(Vector2.left);
                GameManager.FindInstance().SpawnDamageNumber(shoot2Damage, hit);
                shake.TriggerShake();
            }
        }

    }

    public void Shoot4()
    {
        if (transform.localScale.x > 0)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, Mathf.Infinity, LayerMask.GetMask("Enemy"));
            if (hitInfo)
            {
                //TODO
                //add explosion
                //update healthbar

                hitInfo.transform.gameObject.GetComponent<Entity>().TakeDamage(shoot4Damage);
                hitInfo.transform.gameObject.GetComponent<Entity>().Stun();
                GameManager.FindInstance().SpawnDamageNumber(shoot4Damage, hitInfo);
            }
        }
        else if (transform.localScale.x < 0)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right * -1, Mathf.Infinity, LayerMask.GetMask("Enemy"));
            if (hitInfo)
            {
                //TODO
                //add explosion
                //update healthbar

                hitInfo.transform.gameObject.GetComponent<Entity>().TakeDamage(shoot4Damage);
                hitInfo.transform.gameObject.GetComponent<Entity>().Stun();
                GameManager.FindInstance().SpawnDamageNumber(shoot4Damage, hitInfo);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rope")
        {
            canClimb = true;
          

        }
       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Rope")
        {
            canClimb = false;
        }
    }

   
}


