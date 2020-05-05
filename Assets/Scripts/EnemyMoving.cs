using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private Transform _current;
    [SerializeField] private float _speed;

    private Transform _target;
    private SpriteRenderer _renderer;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _target = _pointA;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(_current.position, _target.position, _speed * Time.deltaTime);

        if (_current.position == _pointB.position)
        {
            _target = _pointA;
            _renderer.flipX = false;
        }
        else if (_current.position == _pointA.position)
        {
            _target = _pointB;
            _renderer.flipX = true;
        }
    }
}