using System;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 8f;
    [SerializeField] float rotationSpeed = 360f;

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
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        GatherInput();
        Look();

    }
    private void Move()
    {
      /*  Vector3 moveDirection = new Vector3(movementInput.x, 0, movementInput.y);
        moveDirection = moveDirection.normalized;*/
        playerRb.MovePosition(transform.position + transform.forward * playerSpeed * Time.deltaTime);

    }
    private void Look()
    {
      /*  if (movementInput == Vector3.zero)
        {
            return;
        }
        Matrix4x4 isometricMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
        Vector3 rotatedInput = isometricMatrix.MultiplyPoint3x4(movementInput);
        Quaternion targetRotation = Quaternion.LookRotation(rotatedInput, Vector3.up);
        playerRb.MoveRotation(Quaternion.RotateTowards(playerRb.rotation, targetRotation, rotationSpeed * Time.deltaTime));*/

        var relative = (transform.position + movementInput) - transform.position;
        var rotation = quaternion.LookRotation(relative, Vector3.up);

        transform.rotation = rotation;
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
