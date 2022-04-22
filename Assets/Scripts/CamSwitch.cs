using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject secondCamera;
    public GameObject fpsMode;
    public bool isToggled = false;

    public void SwitchView()
    {
        if (mainCamera.active)
        {
            mainCamera.SetActive(false);
            secondCamera.SetActive(true);
        } 
        else if (secondCamera.active)
        {
            secondCamera.SetActive(false);
            fpsMode.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            fpsMode.SetActive(false);
            mainCamera.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Update()
    {
        if (fpsMode.active) 
        {
            if (Input.GetButton("Cancel"))
            {
                fpsMode.SetActive(false);
                mainCamera.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            if (Input.GetButton("Toggle"))
            {
                if (!isToggled)
                {
                    Cursor.lockState = CursorLockMode.None;
                    isToggled = true;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    isToggled = false;
                }
            }
        }
    }
}
