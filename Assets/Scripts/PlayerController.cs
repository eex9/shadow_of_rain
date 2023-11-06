using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float posX;
    public float posY;
    public float posZ;

    public float jumpHeight;
    readonly float JUMPSPEED = 60; // 60 = 1 second
    bool isJumping;
    float jumpTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() 
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        posX += horizontal;
        posZ += vertical;

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            isJumping = true;
            jumpTimer = JUMPSPEED * 2;
        }

        if (isJumping) 
        {
            posY += (1/jumpHeight) * Time.deltaTime * (jumpTimer-JUMPSPEED)/2; // math .
            jumpTimer--;
        }

        if (jumpTimer <= 0) {
            isJumping = false;
            posY = 0;
        }

        transform.position = new Vector2(posX, posY + posZ); // set the player's position

        GameObject shadow = GameObject.Find("Shadow"); // find the shadow and move it to below the player
        shadow.transform.position = new Vector2(posX, posZ - 0.5f);
    }
}
