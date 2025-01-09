using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Gun gun;
    private PlayerInputMap _playerInputMap;
    
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
        playerMovement.Turn(_playerInputMap.Movement.Turn.ReadValue<Vector2>());
        
        if (_playerInputMap.Combat.Shoot.triggered)
        {
            gun.Shoot();
        }
    }
    
    private void OnDisable()
    {
        _playerInputMap.Disable();
    }
}
