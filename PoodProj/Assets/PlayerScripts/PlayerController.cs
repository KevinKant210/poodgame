using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public GameObject scopeOverlay;
    //the maximum or 'base' FOV
    float maxFOV = 60f;
    //the minimum or 'zoom' FOV    //Numbers on both FOVs are placeholder until gun is integrated
    float minFOV = 15f;
    float zoomInput;
    float shootInput;

    public void Start()
    {
        scopeOverlay.SetActive(false);
    }
    

    //passes zoomInput in from InputController whenever the zoom event updates
    public void OnZoomInput(float zoomInput)
    {
        this.zoomInput = zoomInput;
        //sets the FOV to the default max and then checks if the zoom button is pressed
        //if the zoom button is pressed, then it sets the FOV to the zoom FOV
        vcam.m_Lens.FieldOfView = maxFOV;
        scopeOverlay.SetActive(false);
        if (zoomInput == 1)
        {
            vcam.m_Lens.FieldOfView = minFOV;
            scopeOverlay.SetActive(true);
        }
        Debug.Log($"Player Controller Zoom Input:{zoomInput}");
    }

    public void OnShootInput(float shootInput)
    {
        this.shootInput = shootInput;
       
        Debug.Log($"Player Controller Shoot Input:{shootInput}");
    }
}
