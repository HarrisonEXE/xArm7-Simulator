using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpdateSpeed : MonoBehaviour 
{
    private static Slider slider;
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    public static void onSlide()
    { 
        RobotController.updateSpeed(slider.value);
    }
}
