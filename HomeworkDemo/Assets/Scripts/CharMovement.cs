using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float movementSpeed;
    
    private Vector2 _movement;

    private enum MoveParams
    {
        Horizontal,
        Vertical,
        Speed
    }
    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _movement.x = Input.GetAxisRaw(nameof(MoveParams.Horizontal));
        _movement.y = Input.GetAxisRaw(nameof(MoveParams.Vertical));
        AnimateChar();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_movement.x, _movement.y).normalized * movementSpeed;
    }

    private void AnimateChar()
    {
        _animator.SetFloat(nameof(MoveParams.Speed), _movement.magnitude);
        _animator.SetFloat(nameof(MoveParams.Horizontal), _movement.x);
        _animator.SetFloat(nameof(MoveParams.Vertical), _movement.y);
    }
    
    
}
