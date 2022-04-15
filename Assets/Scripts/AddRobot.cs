using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRobot : MonoBehaviour
{
    public ArticulationBody targetArm; //Maybe should find object by tag instead

    public void OnButtonClick()
    {
        //Debug.Log(targetArm.anchorPosition);
        targetArm.TeleportRoot(new Vector3(-0.05f, 0, 0), Quaternion.identity);
    }
}
