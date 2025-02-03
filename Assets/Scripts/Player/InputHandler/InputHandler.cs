using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Gun gun;
    private PlayerInputMap _playerInputMap;

    public UnityEvent OnShootRelease;
    
    private void Awake()
    {
        _playerInputMap = new PlayerInputMap();
    }

    private void OnEnable()
    {
        _playerInputMap.Enable();
    }

    private void Update()
    {
        playerMovement.SetMoveInputValue(_playerInputMap.Movement.Move.ReadValue<Vector2>());
        playerMovement.SetTurnInputValue(_playerInputMap.Movement.Turn.ReadValue<Vector2>());
        
        if (_playerInputMap.Combat.Shoot.inProgress)
        {
            gun.Shoot();
        }
        else if (_playerInputMap.Combat.Shoot.WasReleasedThisFrame())
        {
            OnShootRelease?.Invoke();
        }

    }
    
    private void OnDisable()
    {
        _playerInputMap.Disable();
    }
}
