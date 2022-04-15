using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRobot : MonoBehaviour
{
    public ArticulationBody targetArm; //Maybe should find object by tag instead

    public void OnButtonClick()
    {
        Debug.Log(targetArm.anchorPosition);
        targetArm.TeleportRoot(new Vector3(50f, 50f, 50f), Quaternion.identity);

    }
}
