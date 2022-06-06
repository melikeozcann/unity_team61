using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 400f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private bool grounded;
    private bool started;
    private bool jumping;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        grounded = true;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(name:"space"))
        {
            if ( started && grounded)
            {
                _animator.SetTrigger(name: "Jump");
                grounded = false;
                jumping = true;
            }
           else
            {
                _animator.SetBool(name: "GameStarted", value: true);
                started = true;
            }
        }
        _animator.SetBool(name: "Grounded", grounded);


    }
   
    private void FixedUpdate()
    {
        if (started==true)
        {
            _rigidbody2D.velocity = new Vector2(x: speed, _rigidbody2D.velocity.y);
        }
        if (jumping==true)
        {
            _rigidbody2D.AddForce(new Vector2(x: 0f, y: jumpForce));
            jumping = false;
            grounded = true;
            
        }
    }

    private void OncollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            {
            grounded = true;
        }
    }

}
