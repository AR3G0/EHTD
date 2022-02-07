using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement speed
    public float moveSpeed = 5f;

    //rigid body reference
    public Rigidbody2D rb;

    //variable used to transfer input into variable
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
