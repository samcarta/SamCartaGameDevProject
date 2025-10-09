using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    float movementX;
    float movementY;
    bool jumping = false;
    [SerializeField] float speed = 7f;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] float jumpPower = 5f;

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("walking", movementX != 0f);
    }


    void OnMove(InputValue value){
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;

        Debug.Log(v);
    }

    void FixedUpdate(){
        float XmoveDistance = movementX * speed;

        rb.linearVelocityX = XmoveDistance;
        //rb.linearVelocity = new Vector2(movementX,movementY).normalized;

        if (touchingGround && jumping)
        {
            rb.AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
            jumping = false;
        }
    }

    void OnJump()
    {
        if (touchingGround)
        {
            jumping = true;
        }
    }



    bool touchingGround;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            touchingGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            touchingGround = false;
        }
    }

}
