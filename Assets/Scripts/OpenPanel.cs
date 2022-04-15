using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Overlay;
    
    public void DisplayPanel()
    {
       Panel.SetActive(true);
       Overlay.SetActive(false);
    }
    
}
