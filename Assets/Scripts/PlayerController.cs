using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpForce;
    float h =0f;
    public Joystick joystick;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool jump = false;
    private Animator anim;
    private bool noChao = false;
    private Transform groundCheck;

	// Use this for initialization
	void Start () {

        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        groundCheck =  gameObject.transform.Find("GroundCheck");

	}
	
	// Update is called once per frame
	void Update () {
        float v = joystick.Vertical;
        bool b = Input.GetButtonDown("Fire1");

        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        
        if(v >= .2f && noChao)
        {
            jump = true;
            anim.SetTrigger("Pulou");
        }else if(joystick.Vertical <= -2f)
        {
            jump = false;
        }

        

	}

    void FixedUpdate()
    {
        
        
        if (joystick.Horizontal >= .01f)
        {
             h =  speed;
        } else if (joystick.Horizontal <= -.01f)
            
            {
                 h = -speed;
            } else{
                h = 0f;
            }
    

       
        
        anim.SetFloat("Velocidade", Mathf.Abs(h));

        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        if(h > 0 && !facingRight)
        {
            Flip();
        }
        else if(h < 0 && facingRight)
        {
            Flip();
        }

        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }

    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
