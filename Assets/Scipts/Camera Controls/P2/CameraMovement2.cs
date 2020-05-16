using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement2 : MonoBehaviour
{
    float horizontal, vertical, rotation;
    public float movementSpeed, rotationSpeed;

    Vector3 nextTranslation;
    Vector3 nextRotation;

    private PlayerControls lookmove;
    // Update is called once per frame

    private void Awake()
    {
        lookmove = new PlayerControls();
        lookmove.PlayerMovement.Look.performed += context => nextRotation = context.ReadValue<Vector3>();
    }








    void Update()
    {
        nextTranslation = Vector3.zero;
        nextRotation = Vector3.zero;

        horizontal = Input.GetAxisRaw("Horizontal2");
        vertical = Input.GetAxisRaw("Vertical2");
        rotation = Input.GetAxisRaw("Rotate2");




        nextTranslation.x = horizontal;
        nextTranslation.z = vertical;
        nextTranslation *= movementSpeed * Time.deltaTime;
        if (nextTranslation != Vector3.zero)
            transform.Translate(nextTranslation);

        nextRotation.y = rotation * rotationSpeed * Time.deltaTime;
        transform.Rotate(nextRotation);

        Camera.main.transform.LookAt(transform);
    }


    //private void OnEnable()
    //{
    //    lookmove.Enable();
    //}

    //private void OnDisable()
    //{
    //    lookmove.Disable();
    //}
}
