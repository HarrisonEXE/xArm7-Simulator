using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EditModeToggle : MonoBehaviour
{
    public GameObject DefaultUIGroup;
    public GameObject EditingUIGroup;
    public static bool EditModeActive = false;

    public void ToggleEditMode()
    {
        DefaultUIGroup.SetActive(EditModeActive);
        EditingUIGroup.SetActive(!EditModeActive);
        EditModeActive = !EditModeActive;
    }
}
