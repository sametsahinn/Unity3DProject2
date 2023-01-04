using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : IInputReader
{
    PlayerInput playerInput;

    public float Horizontal { get; private set; }
    public bool Jump { get; private set; }

    public InputReader(PlayerInput playerInput)
    {
        this.playerInput = playerInput;

        playerInput.currentActionMap.actions[0].performed += OnHorizontalMove;
        playerInput.currentActionMap.actions[1].started += OnJump;
        playerInput.currentActionMap.actions[1].canceled += OnJump;
    }

    private void OnHorizontalMove(InputAction.CallbackContext obj)
    {
        Horizontal = obj.ReadValue<float>();
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        Jump = obj.ReadValueAsButton();
    }
}
