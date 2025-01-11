using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways, DisallowMultipleComponent]
public class CameraController : MonoBehaviour
{
    private static CameraController _cameraController;
    
    [SerializeField] private Transform lookAt;
    [SerializeField] private CameraOffsetSettings cameraOffsetSettings;
    [SerializeField, Range(0,10)] private float smoothSpeed;
    
    private Camera _mainCamera;
    private void Awake()
    {
        if (_cameraController == null)
        {
            _cameraController = this;
        }
        else
        {
            Debug.LogWarning("There is already a CameraController in the scene " + _cameraController.gameObject.name);
        }
        
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        HandleCameraPosition();
        SmoothCameraMovement();
    }

    private void HandleCameraPosition()
    {
        if (Application.isPlaying) return;
        
        if(lookAt == null) return;

        _mainCamera.transform.position = lookAt.transform.position + new Vector3(cameraOffsetSettings.xOffset, cameraOffsetSettings.yOffset, cameraOffsetSettings.zOffset);
        _mainCamera.transform.LookAt(lookAt);
    }

    private void SmoothCameraMovement()
    {
        _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position,
            lookAt.transform.position + new Vector3(cameraOffsetSettings.xOffset, cameraOffsetSettings.yOffset,
                cameraOffsetSettings.zOffset), smoothSpeed * Time.deltaTime);
    }
}
