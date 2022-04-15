using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Overlay;

    public void RemovePanel()
    {
        Panel.SetActive(false);
        Overlay.SetActive(true);
    }

}
