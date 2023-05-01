using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    #region VARIABLES
    [Header("Speed Setup")]
    [SerializeField] private Vector2 friction;
    [SerializeField] private float speedWalk;
    [SerializeField] private float speedRun;
    [SerializeField] private float jumpForce;

    [Header("Animation Setup")]
    [SerializeField] private Ease ease;
    [SerializeField] private float jumpScaleY = 1.5f;
    [SerializeField] private float jumpScaleX = 0.7f;
    [SerializeField] private float floorScaleY = 0.5f;
    [SerializeField] private float jumpAnimationDuration = .3f;
    [SerializeField] private float floorAnimationDuration = .3f;

    private Rigidbody2D _Rb2D;
    private bool _isRunning;
    private bool _isInTheFloor = true;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Condition to see if the gameObject colliding have the tag "Floor";
        if (collision.gameObject.CompareTag("Floor"))
        {
            _Rb2D.transform.localScale = Vector2.one;

            // Condition to control the animation os hit the floor;
            if (!_isInTheFloor)
            {
                DOTween.Kill(_Rb2D.transform);
                HandleScaleOnFloor();
            }

            _isInTheFloor = true;

        }
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
        // Jump if Space was pressed, also do an animation with scale;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isInTheFloor)
            {
                _Rb2D.velocity = Vector2.up * jumpForce;
                _Rb2D.transform.localScale = Vector2.one;

                DOTween.Kill(_Rb2D.transform);

                HandleScaleJump();

                _isInTheFloor = false;
            }
        }
    }


    private void HandleScaleJump()
    {
        // Animation with scale make with DG.Tweening;
        _Rb2D.transform.DOScaleY(jumpScaleY, jumpAnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        _Rb2D.transform.DOScaleX(jumpScaleX, jumpAnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    private void HandleScaleOnFloor()
    {
        // Animation with scale make with DG.Tweening;
        _Rb2D.transform.DOScaleY(floorScaleY, floorAnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
