using System;
using System.Collections;
using System.Collections.Generic;
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

    public Material selectedMat;
    private Material mat;

    private void Awake()
    {
        inputs = new Inputs();
        inputs.Placement.Enable();
        //inputs.Placement.MainClick. += OnClick;
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    private RaycastHit hit;
    private void Update()
    {
        if (inputs.Placement.MainClick.WasPerformedThisFrame())
        {
            Debug.Log("performed");
            Debug.Log(inputs.Placement.ClickPosition.ReadValue<Vector2>());
            if (Physics.Raycast(cam.ScreenPointToRay(inputs.Placement.ClickPosition.ReadValue<Vector2>()),out hit, 1000))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.TryGetComponent<Furniture>(out Furniture f))
                {
                    movingFurniture = f;
                    movingFurnitureLastPos = f.transform.position;
                    movingFurnitureLastRot = f.transform.rotation;
                    mat = movingFurniture.r.material;
                    movingFurniture.r.material = selectedMat;
                }
            }
        }

        if (inputs.Placement.MainClick.WasReleasedThisFrame())
        {
            Debug.Log("released");
            if (movingFurniture != null)
            {
                //Cancel movement
                if (movingFurniture.IsColliding)
                    movingFurniture.transform.position = movingFurnitureLastPos;

                movingFurniture.r.material = mat;
            }
            movingFurniture = null;
        }
    }

    private void LateUpdate()
    {
        //Move around the furniture
        if (movingFurniture != null)
        {
            if (Physics.Raycast(cam.ScreenPointToRay(inputs.Placement.ClickPosition.ReadValue<Vector2>()), out hit, 1000, placementMask))
            {
                movingFurniture.transform.position = hit.point;
            }
        }
    }
}
