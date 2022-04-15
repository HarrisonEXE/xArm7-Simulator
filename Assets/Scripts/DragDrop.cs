using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using System.Range;
//using System.Index;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private ArticulationBody targetArm;
    private GameObject floor;
    private float panelWidth = 354.196f;
    private float panelHeight = 280f;
    //Panel size: 354.196 by 280
    //Floor size: 236.2204 by 196.7379
    // Floor center: -349.8982, -0.9054307
    // Left bound: -352.2482
    // Right bound: -347.5482
    // Back bound: 1.0445693
    // Front bound: -2.8554307
    // Starting arm pos: -350 (+2.2482), -2 (-0.9554307) //using left bound and back bound

    private float scalingFactor;
    
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        targetArm = SelectArm.getArm();
        floor = GameObject.FindGameObjectsWithTag("Ground")[0];
        //Debug.Log(floor.GetComponent<Collider>().bounds.size);
        scalingFactor = panelWidth / floor.GetComponent<Collider>().bounds.size[0]; //panel width hard-coded :P
        Debug.Log(scalingFactor * 2.2482 + " and " + scalingFactor * 0.9554307);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        targetArm = SelectArm.getArm();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //TODO: Find a better mapping function
        canvasGroup.alpha = 1f;
        Debug.Log(rectTransform.anchoredPosition);
        float xPos = (rectTransform.anchoredPosition[0] - (-panelWidth / 2)) / scalingFactor - 3.7686f;
        float zPos = (rectTransform.anchoredPosition[1] - (-panelHeight / 2)) / scalingFactor - 3f;
        Debug.Log("New measure: " + xPos);
        Vector3 vec = new Vector3(xPos, targetArm.transform.position[1], zPos);
        targetArm.TeleportRoot(vec, new Quaternion(0.353553355f, 0.612372458f, -0.612372458f, 0.353553355f));
    }
}
