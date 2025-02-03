using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private Animator playerAnimatorController;

    private Rigidbody _rigidbody;
    private Vector2 _moveInputValue;    
    private Vector2 _turnInputValue;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        Move();
        Turn();
    }
    
    private void Move()
    {
        if (_moveInputValue == Vector2.zero)
        {
            _rigidbody.velocity = Vector3.zero;
            playerAnimatorController.SetBool("IsWalking", false);
            return;
        }
        
        _rigidbody.velocity = new Vector3(_moveInputValue.x * moveSpeed, 0, _moveInputValue.y * moveSpeed);

        if (playerAnimatorController.GetBool("IsWalking")) return;
        playerAnimatorController.SetBool("IsWalking", true);
    }


    private void Turn()
    {
        if (_turnInputValue == Vector2.zero) return;
        
        var targetRotation = Quaternion.LookRotation(new Vector3(_turnInputValue.x, 0, _turnInputValue.y));
        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        _rigidbody.MoveRotation(targetRotation);
    }

    public void SetMoveInputValue(Vector2 value)
    {
        _moveInputValue = value;
    }
    
    public void SetTurnInputValue(Vector2 value)
    {
        _turnInputValue = value;
    }
}
