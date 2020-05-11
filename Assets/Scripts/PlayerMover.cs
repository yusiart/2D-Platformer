using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpAcceleration;

    private Animator _animator;
    private bool _isGrounded = true;
    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;
    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
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
            _rigidbody.velocity = new Vector2(0, _jumpAcceleration);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Crystal>(out Crystal crystal))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            _isGrounded = true;
        }
    }
}