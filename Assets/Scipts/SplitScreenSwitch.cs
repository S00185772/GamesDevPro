using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class SplitScreenSwitch : MonoBehaviour
{
    public Camera cam1, cam2;

   public PlayerControls controls;

    private bool isHorizontalSplit;

    public InputAction lookAction;
    //PlayerInput
    private void Awake()
    {
      //controls.PlayerMovement.SplitScreen.performed += ctx =>Update() ;
    }




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))

        {
            setSplitScreen();
        isHorizontalSplit = !isHorizontalSplit;


        }


    }

     void Look()
    {
        setSplitScreen();
        isHorizontalSplit = !isHorizontalSplit;
    }

    public void setSplitScreen()
    {
        if (isHorizontalSplit)
        {
            cam1.rect = new Rect(0f, .5f, 1f, .5f);
            cam2.rect = new Rect(0, 0f, 1f, .5f);
        }
        else
        {
            cam1.rect = new Rect(0f, 0f, .5f, 1f);
            cam2.rect = new Rect(.5f, 0f, .5f, 1f);


        }
        
    }


    //private void OnEnable()
    //{
    //    controls.PlayerMovement.SplitScreen.Enable();
    //}

    //private void OnDisable()
    //{
    //    controls.PlayerMovement.SplitScreen.Disable();
    //}



}
