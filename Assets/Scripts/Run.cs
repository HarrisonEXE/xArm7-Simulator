using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public void OnButtonClick()
    {
        RobotController.setReady();
        ArticulationJointController.changeMode(false);
    }
    
}
