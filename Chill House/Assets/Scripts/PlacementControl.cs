using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlacementControl : MonoBehaviour
{
    public Camera cam;
    public LayerMask placementMask;
    public LayerMask furnitures;
    public float lerpSpeed;
    private Inputs inputs;
    public UIOverGameobject anchorPointer;

    private Furniture movingFurniture;
    private Vector3 movingFurnitureLastPos;
    private Quaternion movingFurnitureLastRot;

    public Material goodPosMat;
    public Material wrongPosMat;
    public float rotationSpeed;
    private Material mat;

    private void Awake()
    {
        inputs = new Inputs();
        inputs.Placement.Enable();
        anchorPointer.SetVisibility(false);
    }

    private RaycastHit hit;
    private Vector2 mousePositionOffset;
    private bool rotating = false;
    private Vector2 savedCursorPos;

    private void Update()
    {
        if (inputs.Placement.MainClick.WasPerformedThisFrame())
        {
            if (Physics.Raycast(cam.ScreenPointToRay(inputs.Placement.PointerPosition.ReadValue<Vector2>()), out hit, 1000))
            {
                //SELECT THE FURNITURE
                if (hit.collider.gameObject.TryGetComponent<Furniture>(out Furniture f))
                {
                    movingFurniture = f;
                    movingFurnitureLastPos = f.transform.position;
                    movingFurnitureLastRot = f.transform.rotation;
                    mat = movingFurniture.r.material;
                    movingFurniture.r.material = goodPosMat;
                    anchorPointer.SetVisibility(true);
                    anchorPointer.target = (movingFurniture.transform);

                    Vector3 offset = Vector3.zero;
                    if (f.surface.collider != null)
                    {
                        Debug.Log(f.surface.normal);
                        if (f.surface.normal != Vector3.up)
                            offset = f.surface.normal * f.col.bounds.size.x * .5f;
                    }
                    mousePositionOffset = (Vector2)cam.WorldToScreenPoint(f.transform.position - offset) - inputs.Placement.PointerPosition.ReadValue<Vector2>();
                    Cursor.visible = false;
                }
            }
        }

        //RELEASE FURNITURE
        if (inputs.Placement.MainClick.WasReleasedThisFrame())
        {
            if (movingFurniture != null)
            {
                //Cancel movement
                if (movingFurniture.IsColliding)
                {
                    movingFurniture.transform.position = movingFurnitureLastPos;
                    movingFurniture.transform.rotation = movingFurnitureLastRot;
                }
                else
                {
                    //if (Physics.Raycast(cam.ScreenPointToRay((inputs.Placement.PointerPosition.ReadValue<Vector2>() + mousePositionOffset)), out hit, 1000, placementMask))
                    {
                        movingFurniture.surface = hit;
                    }
                }
                movingFurniture.r.material = mat;
                anchorPointer.SetVisibility(false);
                //Win32.POINT pt = new Win32.POINT();
                //Win32.GetCursorPos(out pt);
                //savedCursorPos = new Vector2(pt.X, pt.Y);
                Win32.SetCursorPos((int)mousePositionOffset.x, (int)mousePositionOffset.y);
                Cursor.visible = true;
                anchorPointer.target = null;
            }
            movingFurniture = null;
        }

        if (inputs.Placement.SecondClick.WasPerformedThisFrame())
        {
            rotating = true;

            //Save cursor position
            //Win32.POINT pt = new Win32.POINT();
            //Win32.GetCursorPos(out pt);
            //savedCursorPos = new Vector2(pt.X, pt.Y);
            //savedFPos = movingFurniture.transform.position;
        }
        if (inputs.Placement.SecondClick.WasReleasedThisFrame())
        {
            rotating = false;

            //movingFurniture.transform.position = savedFPos;
        }
    }

    private void LateUpdate()
    {
        //Move around the furniture
        if (movingFurniture != null)
        {
            if (rotating == false)
            {
                if (Physics.Raycast(cam.ScreenPointToRay((inputs.Placement.PointerPosition.ReadValue<Vector2>() + mousePositionOffset)), out hit, 1000, placementMask))
                {
                    Vector3 offset = Vector3.zero;
                    if (hit.normal != Vector3.up)
                    {
                        offset = hit.normal * movingFurniture.col.bounds.size.x / 2;
                    }
                    movingFurniture.transform.position = Vector3.Lerp(movingFurniture.transform.position, hit.point + offset, lerpSpeed * Time.deltaTime);
                    anchorPointer.offset = offset;

                }
            }
            else
            {
                movingFurniture.transform.Rotate(Vector3.up, -inputs.Placement.PointerDelta.ReadValue<Vector2>().x * rotationSpeed * Time.deltaTime);

                //Win32.SetCursorPos((int)savedCursorPos.x, (int)savedCursorPos.y);
            }
            if (movingFurniture.IsColliding)
                movingFurniture.r.material = wrongPosMat;
            else
                movingFurniture.r.material = goodPosMat;
        }
    }
}

public class Win32
{
    [DllImport("User32.Dll")]
    public static extern long SetCursorPos(int x, int y);
    [DllImport("User32.Dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetCursorPos(out POINT lpPoint);

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
