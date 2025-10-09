using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2 : MonoBehaviour
{
    float movementX;
    float movementY;
    [SerializeField] float speed = 7f;

    [SerializeField] Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnMove1(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;

        Debug.Log(v);
    }

    void FixedUpdate()
    {
        float XmoveDistance = movementX * speed;

        rb.linearVelocityX = XmoveDistance;
        //rb.linearVelocity = new Vector2(movementX,movementY).normalized;

    }

}
