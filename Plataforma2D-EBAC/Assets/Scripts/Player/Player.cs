using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 friction;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D _Rb2D;

    private void Awake()
    {
        _Rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // _Rb2D.MovePosition(_Rb2D.position + velocity * Time.deltaTime);
            _Rb2D.velocity = new Vector2(speed, _Rb2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // _Rb2D.MovePosition(_Rb2D.position - velocity * Time.deltaTime);
            _Rb2D.velocity = new Vector2(-speed, _Rb2D.velocity.y);
        }

        if (_Rb2D.velocity.x > 0)
        {
            _Rb2D.velocity += friction;
        }
        else if (_Rb2D.velocity.x < 0)
        {
            _Rb2D.velocity -= friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _Rb2D.velocity = Vector2.up * jumpForce;
        }
    }
}
