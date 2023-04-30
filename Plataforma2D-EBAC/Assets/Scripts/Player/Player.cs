using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;
    [SerializeField] private float speed;

    private Rigidbody2D _Rb2D;

    private void Awake()
    {
        _Rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
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
    }
}
