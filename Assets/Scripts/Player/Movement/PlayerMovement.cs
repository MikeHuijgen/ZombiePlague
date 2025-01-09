using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;

    private Rigidbody _rigidbody;
    private Vector2 _moveInputValue;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 moveInputValue)
    {
        /*if (moveInputValue == Vector2.zero) return;
        
        transform.Translate(new Vector3(moveInputValue.x * speed * Time.deltaTime, 0, moveInputValue.y * speed * Time.deltaTime), Space.World);*/
    }

    private void FixedUpdate()
    {
        if (_moveInputValue == Vector2.zero)
        {
            _rigidbody.velocity = Vector3.zero;
            return;
        }
        
        _rigidbody.velocity = new Vector3(_moveInputValue.x * speed, 0, _moveInputValue.y * speed);
    }

    public void Turn(Vector2 turnInputValue)
    {
        if (turnInputValue == Vector2.zero) return;
        
        var targetRotation = Quaternion.LookRotation(new Vector3(turnInputValue.x, 0, turnInputValue.y));
        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        transform.rotation = targetRotation;
    }

    public void SetMoveInputValue(Vector2 value)
    {
        _moveInputValue = value;
    }
}
