using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOverGameobject : MonoBehaviour
{
    public Transform target;
    public Camera cam;
    public Image img;
    public RectTransform rectTransform;
    public float lerpValue;
    public Vector3 offset = Vector3.zero;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (target != null)
            rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, cam.WorldToScreenPoint(target.position-offset), lerpValue);
    }

    public void SetVisibility(bool visible)
    {
        img.enabled = visible;
    }
}
