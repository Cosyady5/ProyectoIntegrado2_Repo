using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 8f;
    private Rigidbody playerRb;
    private InputActions playerInputActions;
    private Vector3 movementInput;

    private void Awake()
    {
        playerInputActions = new InputActions();
        playerRb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerInputActions.Gameplay.Enable();
        playerInputActions.Gameplay.Attack.performed += Attack;
        playerInputActions.Gameplay.Interact.performed += Interact;
        playerInputActions.Gameplay.Menu.performed += OpenExitMenu;


    }
    private void OnDisable()
    {
        playerInputActions.Gameplay.Disable();
        playerInputActions.Gameplay.Attack.performed -= Attack;
        playerInputActions.Gameplay.Interact.performed -= Interact;
        playerInputActions.Gameplay.Menu.performed -= OpenExitMenu;

    }

    private void Update()
    {
        GatherInput();
        Move();
    }
    private void Move()
    {
        Vector3 moveDirection = new Vector3(movementInput.x, 0, movementInput.y);
        moveDirection = moveDirection.normalized;
        playerRb.MovePosition(transform.position + moveDirection * playerSpeed * Time.deltaTime);
    }
    private void Attack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack");
    }
    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Interact");
    }
    private void OpenExitMenu(InputAction.CallbackContext context)
    {
        
    }
    private void GatherInput()
    {
        Vector2 input = playerInputActions.Gameplay.Move.ReadValue<Vector2>();
        movementInput = new Vector3(input.x, 0, input.y);
    }
}
