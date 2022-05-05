using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AdjustHeight : MonoBehaviour
{
    public GameObject textBox;
    public int index;
    private static ArticulationBody targetArm;
    private static GameObject target = null;

    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Base")[1];
    }
    void OnMouseDown()
    {
        target = gameObject;
        textBox.SetActive(!textBox.active);
        //SelectArm.select(index);
    }
    void Update()
    {
        if (textBox.active)
        {
            if (Input.GetButton("Submit")) 
            {
                InputField input = textBox.GetComponent<InputField>();
                float height = float.Parse(input.text);
                float diffHeight = height - target.transform.localScale.y;

                ArticulationBody targetArm = GameObject.FindGameObjectsWithTag("Arm")[index].GetComponent<ArticulationBody>();              
                Vector3 vec = new Vector3(targetArm.transform.position[0], targetArm.transform.position[1] + (diffHeight), targetArm.transform.position[2]);
                targetArm.TeleportRoot(vec, new Quaternion(0.353553355f, 0.612372458f, -0.612372458f, 0.353553355f));

                target.transform.localScale = new Vector3(0.15f, height, 0.15f);
            }
        }
    }
}
