using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 1;
    public float playerJump = 1;
    private float horizontalDirection;
    private float verticalDirection;
    private Rigidbody2D rb;
    private bool jump = false;
    private bool ground = false;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalDirection = Input.GetAxisRaw("Horizontal");
        verticalDirection = Input.GetAxisRaw("Vertical");
        //transform.position += new Vector3(horizontalDirection, verticalDirection, 0) * Time.deltaTime * playerSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalDirection * playerSpeed, rb.velocity.y);
        if(jump)
        {
            if (ground)
            {
                rb.AddForce(Vector2.up * playerJump, ForceMode2D.Impulse);
                ground = false;
            }                      
            jump = false;
        }      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            ground = true;
        }
    }
}
