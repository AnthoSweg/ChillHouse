using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Furniture : MonoBehaviour
{
    public FurnitureState fState;
    public Renderer r;
    public bool IsColliding
    {
        get { return colliding; }
    }
    private bool colliding;

    private void OnTriggerEnter(Collider other)
    {
        colliding = true;
        Debug.Log(other.gameObject.name);
    }
    private void OnTriggerExit(Collider other)
    {
        colliding = false;
    }
}

[System.Serializable]
public class FurnitureState
{
    public Vector3 pos;
    public Vector3 rot;
    public int meshIndex;
    //Color
    //2Color
}
