using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D cl;

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
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime * FORCE_STRENGTH;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime * FORCE_STRENGTH;
        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            jumpTimer = JUMPSPEED * 2;
            isJumping = true;
        }

        if (isJumping)
        {
            // Create a graph that accellerates upwards in reducing amounts in the first half, then accellerates downwards.
            addY = -(JUMPSPEED - jumpTimer) * Time.deltaTime * 1/jumpHeight;
            jumpTimer--;
            if (jumpTimer <= -1)
            {
                addY = 0;
                isJumping = false;
                jumpTimer = 0;
                cl.offset = new Vector2(0, 0);
            }
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
