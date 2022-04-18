using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System;

//serialized ZoomInputEvent allows for easy modularity with the player
[Serializable]
public class ZoomInputEvent : UnityEvent<float>{}

[Serializable]
public class ShootInputEvent : UnityEvent<float>{}

public class InputController : MonoBehaviour
{
    Controls controls;
    public ZoomInputEvent zoomInputEvent;
    public ShootInputEvent shootInputEvent;

    //instanciates controls
    private void Awake()
    {
        controls = new Controls();
    }

    //enables controls and allows for zoom to be performed
    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.Zoom.performed += OnZoomPerformed;
        controls.Player.Zoom.canceled += OnZoomPerformed;

        controls.Player.Shoot.performed += OnShootPerformed;
        controls.Player.Shoot.canceled += OnShootPerformed;
    }
    
    
    private void OnZoomPerformed(InputAction.CallbackContext context)
    {
        float zoomInput = context.ReadValue<float>();
        //invoke the ZoomInputEvent so the player character reaction is also working as an event based action
        zoomInputEvent.Invoke(zoomInput);
        Debug.Log($"Zoom Input:{zoomInput}");
    }

    private void OnShootPerformed(InputAction.CallbackContext context)
    {
        float shootInput = context.ReadValue<float>();
        //invoke the ShootInputEvent so the player character reaction is also working as an event based action
        shootInputEvent.Invoke(shootInput);
        Debug.Log($"Shoot Input:{shootInput}");
    }
}
