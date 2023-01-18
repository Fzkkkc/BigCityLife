using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Health")]
    //public int health;


    private bool isGrounded;

    public float speed = 0.01f;

    public float rayDistance = 0.5f;
    public float jumpForce = 2.0f;
    public bool doubleJump = false;


    Rigidbody2D rb2d;
    private Animator anim;



    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }
     private void FixedUpdate()
     {
        RaycastHit2D hit = Physics2D.Raycast(rb2d.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            isGrounded = true;
            doubleJump = false;
        }
        else
        {
            isGrounded = false;
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            else if (!doubleJump && rb2d.velocity.y < 0)
            {
                doubleJump = true;
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }

        //transform.Translate(new Vector3(0.01f, 0, 0));
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (isGrounded == true)
        {
            anim.SetBool("grounded", true);
        }
        else
        {
            anim.SetBool("grounded", false);
        }
    }
}
