using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresetController : MonoBehaviour
{

    private static GameObject[] arms;
    private bool isToggled = false;
    private Vector3 arm1;
    private Vector3 arm2; //Very proof of concept ik
    private Vector3 arm3;

    void Start()
    {
        arms = GameObject.FindGameObjectsWithTag("Arm");
        arm1 = arms[0].transform.position;
        arm2 = arms[1].transform.position;
        arm3 = arms[2].transform.position;
    }
    public void SwitchPreset()
    {
        if (!isToggled)
        { 
            Vector3 vec = new Vector3(100f, 0f, 0f);
            arms[0].GetComponent<ArticulationBody>().TeleportRoot(vec, new Quaternion(0f, 0f, 0f, 0.353553355f));
            arms[1].GetComponent<ArticulationBody>().TeleportRoot(vec, new Quaternion(0f, 0f, 0f, 0.353553355f));
            arms[2].GetComponent<ArticulationBody>().TeleportRoot(vec, new Quaternion(0f, 0f, 0f, 0.353553355f));
            isToggled = true;
        }
        else
        {
            arms[0].GetComponent<ArticulationBody>().TeleportRoot(arm1, new Quaternion(0.353553355f, 0.612372458f, -0.612372458f, 0.353553355f));
            arms[1].GetComponent<ArticulationBody>().TeleportRoot(arm2, new Quaternion(0.353553355f, 0.612372458f, -0.612372458f, 0.353553355f));
            arms[2].GetComponent<ArticulationBody>().TeleportRoot(arm3, new Quaternion(0.353553355f, 0.612372458f, -0.612372458f, 0.353553355f));
            isToggled = false;
        }
    }

}
