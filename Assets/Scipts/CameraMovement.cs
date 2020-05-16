using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CameraMovement : MonoBehaviour
{

    private PlayerControls lookmove;

    private Vector2 movementInput;
    [SerializeField]

    private float moveSpeed = 10f;

    private Vector3 inputDirection;


    private Vector3 MoveVector;

    private Quaternion currentRotation;



    private void Awake()
    {
        lookmove = new PlayerControls();
        lookmove.PlayerMovement.Look.performed += context => movementInput = context.ReadValue<Vector2>();

    }

    private void FixedUpdate()
    {
        float h = movementInput.x;
        float v = movementInput.y;


        Vector3 targetInput = new Vector3(h, 0, v);

        inputDirection = Vector3.Lerp(inputDirection, targetInput, Time.deltaTime * 10f);

        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0f;
        camRight.y = 0f;

        Vector3 desiredDirection = camForward * inputDirection.z + camRight * inputDirection.x;

        Move(desiredDirection);
        Turn(desiredDirection);


    }

    void Move(Vector3 desiredDirection)
    {
        MoveVector.Set(desiredDirection.x, 0f, desiredDirection.z);
        MoveVector = MoveVector * moveSpeed * Time.deltaTime;
        transform.position += MoveVector;

    }

    void Turn(Vector3 desiredDirection)
    {
        if ((desiredDirection.x > 0.1 || desiredDirection.x < -0.1) || (desiredDirection.z > 0.1 || desiredDirection.z < 0.1))
        {
            currentRotation = Quaternion.LookRotation(desiredDirection);
            transform.rotation = currentRotation;
        }

        else
            transform.rotation = currentRotation;
    }


    private void OnEnable()
    {
        lookmove.Enable();
    }

    private void OnDisable()
    {
        lookmove.Disable();
    }
}
