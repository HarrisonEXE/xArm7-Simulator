using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsolateArm : MonoBehaviour
{
    public static bool isIsolating = false;
    bool pressed = true;
    private static GameObject[] arms;

    void Start()
    {
        arms = GameObject.FindGameObjectsWithTag("Arm");
    }


    public void ToggleIsolation()
    {
        if (isIsolating)
        {
            RemoveIsolation();
            GetComponent<RawImage>().color = Color.white;
            isIsolating = false;
        }
        else
        {
            Isolate();
            GetComponent<RawImage>().color = Color.gray;
            isIsolating = true;
        }
    }

    public static void MaybeIsolate() 
    {
        if (isIsolating)
        {
            Isolate();
        }
    }

    public static void Isolate()
    {
        for (int i = 0; i < arms.Length; i++)
        {
            RobotController robotController = arms[i].GetComponent<RobotController>();
            robotController.setActive(false);
        }
        GameObject arm = SelectArm.getArmObject();
        arm.GetComponent<RobotController>().setActive(true);   
    }
    public void RemoveIsolation()
    {
        for (int i = 0; i < arms.Length; i++)
        {
            RobotController robotController = arms[i].GetComponent<RobotController>();
            robotController.setActive(true);
        }
    }
}
