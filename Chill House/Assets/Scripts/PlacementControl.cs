using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlacementControl : MonoBehaviour
{
    public Camera cam;
    public LayerMask placementMask;
    public LayerMask furnitures;
    private Inputs inputs;

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

                    mousePositionOffset = (Vector2)cam.WorldToScreenPoint(f.transform.position) - inputs.Placement.PointerPosition.ReadValue<Vector2>();
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
                movingFurniture.r.material = mat;
            }
            movingFurniture = null;
        }

        if (inputs.Placement.SecondClick.WasPerformedThisFrame())
        {
            rotating = true;

            //Save cursor position
            Win32.POINT pt = new Win32.POINT();
            Win32.GetCursorPos(out pt);
            savedCursorPos = new Vector2(pt.X, pt.Y);
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
                    movingFurniture.transform.position = hit.point;

                }
            }
            else
            {
                movingFurniture.transform.Rotate(Vector3.up, -inputs.Placement.PointerDelta.ReadValue<Vector2>().x * rotationSpeed * Time.deltaTime);

                Win32.SetCursorPos((int)savedCursorPos.x, (int)savedCursorPos.y);
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
