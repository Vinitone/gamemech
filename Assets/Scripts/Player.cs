using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField] private float maxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    [SerializeField] private float jumpForce = 400f;                  // Amount of force added when the player jumps.

    [SerializeField] private bool doubleJump = false;
    [SerializeField] private bool airControl = false;                 // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask whatIsGround;                  // A mask determining what is ground to the character

    [SerializeField]
    public Stat health;
    [SerializeField]
    public Stat stamina;

    [SerializeField ]private Transform playerCollider;    // A position marking where to check if the player is grounded.
    const float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    public bool grounded;            // Whether or not the player is grounded.
    const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Animator anim;            // Reference to the player's animator component.
    private Rigidbody2D rigidbody2D;
    public bool facingRight = true;  // For determining which way the player is currently facing.    
    //public AudioClip jumpSound;

    private void Awake()
    {
        // Setting up references.
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        health.Initialize();
        stamina.Initialize();
    }


    private void FixedUpdate()
    {
        grounded = false;
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.2f, whatIsGround);
        if(hit.collider != null)
        { grounded = true; }
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
    }


    public void Move(float move, bool crouch, bool roll, bool jump, bool run)
    {
        //only control the player if grounded or airControl is turned on
        if (grounded || airControl)
        {
            anim.SetFloat("Speed", Mathf.Abs(move));
            anim.SetBool("Run", run);
            // Move the character
 
            if (run && grounded)
                rigidbody2D.velocity = new Vector2(move * maxSpeed * 1.5f, rigidbody2D.velocity.y);
            else
                rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
            
            //If the input is moving the player right and the player is facing left...
            if (move > 0 && !facingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && facingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
        // If the player should jump...
        if (jump)
        {
            if (grounded  )
            {
                // Add a vertical force to the player.
        
                //grounded = false;
                //anim.SetBool("Ground", false);
                
                
                rigidbody2D.AddForce(new Vector2(0f, jumpForce));
                doubleJump = true;
                //SoundManager.instance.PlaySingle(jumpSound);
            }
            else
            {
                if (doubleJump)
                {
                    doubleJump = false;
                    rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
                    rigidbody2D.AddForce(new Vector2(0f, jumpForce));
                }
            }
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
