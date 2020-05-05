using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;

    private Animator _animator;
    private bool _isGrounded = true;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _renderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _renderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            _rigidbody.velocity = new Vector2(0, _jumpSpeed);
            _isGrounded = false;
        }

        if (Input.anyKey)
        {
            _animator.SetBool("isRun", true);
        }
        else
        {
            _animator.SetBool("isRun", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }

        if (collision.gameObject.tag == "Crystal")
        {
            Destroy(collision.gameObject);
        }
    }
}