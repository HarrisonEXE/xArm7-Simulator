using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class SelectArm : MonoBehaviour
{
    private static ArticulationBody targetArm;
    private static GameObject light;

    void Start()
    {
        targetArm = GameObject.FindGameObjectsWithTag("StartArm")[0].GetComponent<ArticulationBody>();
        light = GameObject.FindGameObjectsWithTag("Spotlight")[0];
        light.transform.position = new Vector3(targetArm.transform.position[0], light.transform.position[1], targetArm.transform.position[2]);
    }
    void Update()
    {
        MoveLight(); //this is some lazy shit
    }

    void OnMouseDown()
    {
        MoveLight();
        targetArm = gameObject.GetComponent<ArticulationBody>();
    }
    public static ArticulationBody getArm()
    {
        return targetArm;
    }
    public void MoveLight()
    {
        light.transform.position = new Vector3(targetArm.transform.position[0], light.transform.position[1], targetArm.transform.position[2]);
    }
}