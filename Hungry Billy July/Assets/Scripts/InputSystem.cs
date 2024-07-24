using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputSystem : MonoBehaviour
{
    public bool mapInitialised = false;

    public InputActionReference startGame;

    private void OnEnable()
    {
        startGame.action.started += StartGame;
    }

    private void OnDisable()
    {
        startGame.action.started -= StartGame;
    }

    private void StartGame(InputAction.CallbackContext obj)
    {
        if(mapInitialised)
        {
            Debug.Log(Time.time + " initialised");
        }
        else
        {
            Debug.Log(Time.time + " uninitialised");
        }
    }
}
