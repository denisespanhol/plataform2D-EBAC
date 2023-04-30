using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private Vector2 friction;

    [SerializeField] private float speedWalk;
    [SerializeField] private float speedRun;
    [SerializeField] private float jumpForce;

    private Rigidbody2D _Rb2D;

    private bool _isRunning;
    #endregion

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
        _isRunning = Input.GetKey(KeyCode.LeftControl);

        // Conditionals to do the horizontal movement of Walk and Run;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _Rb2D.velocity = new Vector2(_isRunning ? speedRun : speedWalk, _Rb2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _Rb2D.velocity = new Vector2(_isRunning ? -speedRun : -speedWalk, _Rb2D.velocity.y);
        }

        // Conditionals to stabilize the player without friction in the floors;
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
