using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private Transform _currentPosition;
    [SerializeField] private float _speed;

    private Transform _target;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _target = _pointA;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(_currentPosition.position, _target.position, _speed * Time.deltaTime);

        if (_currentPosition.position == _pointB.position)
        {
            _target = _pointA;
            _renderer.flipX = false;
        }
        else if (_currentPosition.position == _pointA.position)
        {
            _target = _pointB;
            _renderer.flipX = true;
        }
    }
}