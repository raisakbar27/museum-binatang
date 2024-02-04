using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;

    private PlayerMovement move;
    private PlayerLook look;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        move = GetComponent<PlayerMovement>();
        look = GetComponent<PlayerLook>();
        onFoot.jump.performed += ctx => move.Jump();
        
    }

    // Update is called once per frame
    void Update()
    {
        move.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
       
        
    }

    private void LateUpdate()
    {
         look.ProcessLook(onFoot.Look.ReadValue<Vector2>());

    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
