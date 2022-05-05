using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class SelectArm : MonoBehaviour
{
    private static GameObject target;
    private static ArticulationBody targetArm;
    private static GameObject light;


    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Arm")[1]; //Front middle
        targetArm = target.GetComponent<ArticulationBody>();
        light = GameObject.FindGameObjectsWithTag("Spotlight")[0];
        light.transform.position = new Vector3(targetArm.transform.position[0], light.transform.position[1], targetArm.transform.position[2]);
    }
    void Update()
    {
        MoveLight(); //this is some lazy shit
    }

    void OnMouseDown()
    {
        target = gameObject; ;
        targetArm = target.GetComponent<ArticulationBody>();
        //MoveLight();
        IsolateArm.MaybeIsolate();
        DragDrop.MoveBox(targetArm.transform.position[0], targetArm.transform.position[2]);
    }
    public static ArticulationBody getArm()
    {
        return targetArm;
    }
    public void MoveLight()
    {
        light.transform.position = new Vector3(targetArm.transform.position[0], light.transform.position[1], targetArm.transform.position[2]);
    }
    public static GameObject getArmObject()
    {
        return target;
    }
    public static void select(int index) 
    {
        target = GameObject.FindGameObjectsWithTag("Arm")[index];
        targetArm = target.GetComponent<ArticulationBody>();
    }
}