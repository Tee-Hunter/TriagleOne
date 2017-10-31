using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // float
    public float maxSpeed = 1f;
    public float speed = 5f;
    public float jumpPower = 1f;

    //boolean
    public bool grounded;
    public bool canDoubleJump;

    //reference
    private Rigidbody2D rb2d;
    private Animator anim;

	void Start () { 
        // using arrow to move the character
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
	}
	
	
	void Update () {

        fixedUpdate();

        anim.SetBool("grounded", grounded);
        anim.SetFloat("speed", Mathf.Abs(rb2d.velocity.x)); // please check it

        // moving charactor to the left axis
        if (Input.GetAxis("Horizontal") < -0.1f)
            transform.localScale = new Vector3(-1, 1, 1);

        // moving charactor to the right axis
        if (Input.GetAxis("Horizontal") > 0.1f)
            transform.localScale = new Vector3(1, 1, 1);

        // making jumping
        if (Input.GetButtonDown("Jump"))
        {
            
            if (grounded)
            {
                Debug.Log("grounded");
                canDoubleJump = true;
                rb2d.AddForce(Vector2.up * jumpPower);                
            }
            else
            {
                Debug.Log("not grounded");
                if (canDoubleJump)
                {
                    Debug.Log("double");
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jumpPower);
                    
                }
            }
        }
        
    }

    void fixedUpdate()
    {
        
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x = 0.0f;

        float h = Input.GetAxis("Horizontal"); // Vertical for y Axis

        // Fake friction / easing the x speed our player (ລຸດຜ່ອນການຖູໄຖຂອງ player)
        if (grounded)
        {
            rb2d.velocity = easeVelocity;
        }

        // moving the player
        rb2d.AddForce((Vector2.right * speed) * h);

        // I think these code are setting the maxSpeed, But bro BLACK BEAR just comment this part 
        /*
        //Liniting the speed of the player
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
        }
        */
    }
}
