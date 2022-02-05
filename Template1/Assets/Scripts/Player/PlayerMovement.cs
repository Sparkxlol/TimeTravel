using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollide;
    private Animator anim;
    [SerializeField] private LayerMask groundLayerMask;

    [SerializeField] private float speed = 7.5f;
    [SerializeField] private float jumpPower = 5f;
    private float direction;

    private bool onGround = false;
    private float jumpTime;
    [SerializeField] private float maxJumpTime = .2f;
    [SerializeField] private float downwardForce = 12.5f;

    [SerializeField] private Transform laserPos;
    [SerializeField] private Laser laser;
    private float laserVelocity = 20f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollide = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        groundLayerMask = LayerMask.GetMask("Ground");

        jumpTime = maxJumpTime;
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        onGround = isGrounded();
        jump();
        changeDirection();
        animate();
        shootLaser();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

    private void jump()
    {
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            jumpTime = maxJumpTime;
            rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.Space) && jumpTime > 0) // If kept holding jump and time left, add force.
        {
            rb.AddForce(new Vector2(0, jumpPower / 250), ForceMode2D.Impulse);
            jumpTime -= Time.deltaTime;
        }
        else
            jumpTime = 0;

        if (jumpTime == 0 && rb.velocity.y <= -.001) // If moving downward, speed up.
        {
            float downForce = (rb.velocity.y >= -10) ? rb.velocity.y - (downwardForce * Time.deltaTime) : -10f;
            rb.velocity = new Vector2(rb.velocity.x, downForce);
        }
    }

    // Could possibly exchange for animations, review other games for information.
    public void changeDirection()
    {
        if (direction > 0)
            transform.eulerAngles = Vector3.zero;
        else if (direction < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
    }

    public void animate()
    {
        if (onGround && (direction > .001 || direction < -.001))
            anim.SetBool("walking", true); 
        else
            anim.SetBool("walking", false);
    }

    // Creates a boxcast downward from collider to check if on ground.
    private bool isGrounded()
    {
        float boxCastHeight = .1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollide.bounds.center, boxCollide.bounds.size, 0f, Vector2.down, boxCastHeight, groundLayerMask);
        return raycastHit.collider != null;
    }

    private void shootLaser()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Laser tempLaser = Instantiate(laser, laserPos.position, Quaternion.Euler(new Vector2(0, 0)));
            int laserDir = (transform.eulerAngles.y != 0) ? -1 : 1;
            tempLaser.GetComponent<Rigidbody2D>().AddForce(new Vector2(laserVelocity * laserDir, 0), ForceMode2D.Impulse);
        }
    }
}
