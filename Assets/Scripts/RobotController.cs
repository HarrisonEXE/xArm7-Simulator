using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RobotController : MonoBehaviour
{
    public static List<float[]> data;
    public static bool ready = false;
    public static float dampening = 1f;
    public int robotID;
    public bool isActive = true;

    [System.Serializable]
    public struct Joint
    {
        public string inputAxis;
        public GameObject robotPart;
    }
    public Joint[] joints;

    void Update()
    {
        if (ready)
        {
            StartCoroutine(Dance());
            ready = false;
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Osduchy");
    //}

    // CONTROL
    public static void updateSpeed(float value)
    {
        dampening = value;
    }

    public void StopAllJointRotations()
    {
        for (int i = 0; i < joints.Length; i++)
        {
            GameObject robotPart = joints[i].robotPart;
            UpdateRotationState(RotationDirection.None, robotPart);
        }
    }

    public void RotateJoint(int jointIndex, RotationDirection direction)
    {
        StopAllJointRotations();
        Joint joint = joints[jointIndex];
        UpdateRotationState(direction, joint.robotPart);
    }

    IEnumerator Dance()
    {
        //yield return new WaitForSeconds(1); //might not be needed
        //GameObject robotHead = joints[5].robotPart; //fix eventually
        for (int i = 0; i < data.Count; i++)
        {
            yield return new WaitForSeconds(.006F);
            for (int j = 0; j < 7; j++)
            {   
                float pos = (float)data[i][j + (robotID * 7)];
                Debug.Log("Robot #" + robotID + " is taking a leap of faith");
                UpdateVibes(pos, joints[j].robotPart);
            }
            //yield return new WaitForSeconds(.006F);
            //float pos = (float)data[i];
            //float pos = 0.5f;
            //UpdateVibes(pos, robotHead);
        }
        Debug.Log("Dance Finished!");
        finishDance();
    }


    // HELPERS
    public static void setReady()
    {
        ready = true;
        data = CSVReader.getData();
    }
    public void setActive(bool active)
    {
        isActive = active;
    }
    public static void finishDance()
    {
        ArticulationJointController.changeMode(true);
    }

    public static void setData(List<float[]> newData)
    {
        data = newData;
    }

    static void UpdateRotationState(RotationDirection direction, GameObject robotPart)
    {
        ArticulationJointController jointController = robotPart.GetComponent<ArticulationJointController>();
        jointController.rotationState = direction;
    }

    static void UpdateVibes(float rotation, GameObject robotPart)
    {
        ArticulationJointController jointController = robotPart.GetComponent<ArticulationJointController>();
        jointController.automatedRotation = rotation;
    }


}