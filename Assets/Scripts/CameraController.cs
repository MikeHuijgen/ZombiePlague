using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, DisallowMultipleComponent]
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform lookAt;

    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    [SerializeField] private float zOffset;

    private static CameraController _cameraController;
    
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

    private void OnValidate()
    {
        if(lookAt == null) return;
        
        _mainCamera.transform.position = lookAt.transform.position + new Vector3(xOffset,yOffset,zOffset);
        _mainCamera.transform.LookAt(lookAt);
    }
}
