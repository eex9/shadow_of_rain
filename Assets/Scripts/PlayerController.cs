using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D cl;
    public Animator ani;

    public float speed;

    bool isJumping = false;
    float jumpTimer = 0;
    float addY = 0;
    public float jumpHeight;
    readonly float JUMPSPEED = 60; // 60 = 1 second
    readonly float FORCE_STRENGTH = 100;

    public GameObject shadow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        // Multiply by the constant FORCE_STRENGTH bc unity forces are dumb.
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();
        movement *= speed * Time.deltaTime * FORCE_STRENGTH;
        
        if (horizontal > 0) ani.SetInteger("dir", 1);
        else if (horizontal < 0) ani.SetInteger("dir", 2);
        else if (vertical > 0) ani.SetInteger("dir", 3);
        else if (vertical < 0) ani.SetInteger("dir", 4);
        else ani.SetInteger("dir", 0);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            jumpTimer = JUMPSPEED * 2;
            isJumping = true;
            ani.SetBool("jumping", true;)
        }

        if (isJumping)
        {
            // Create a graph that accellerates upwards in reducing amounts in the first half, then accellerates downwards.
            addY = -(JUMPSPEED - jumpTimer) * Time.deltaTime * 1/jumpHeight;
            jumpTimer--;
            if (jumpTimer < 0)
            {
                addY = 0;
                isJumping = false;
                jumpTimer = 0;
                cl.offset = new Vector2(0, 0);
                ani.SetBool("jumping", false);
            }
            // TODO: Use Physics2D.CircleCast to check if the player would collide at their position and change their jump if not
        }

        // Apply movement using unity forces system
        rb.AddForce(movement);
        cl.offset -= new Vector2(0, addY);
        transform.position += new Vector3(0, addY, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        
    }
}
