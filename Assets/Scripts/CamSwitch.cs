using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject secondCamera;

    public void SwitchView()
    {
        mainCamera.SetActive(!mainCamera.active);
        secondCamera.SetActive(!secondCamera.active);
    }
}
