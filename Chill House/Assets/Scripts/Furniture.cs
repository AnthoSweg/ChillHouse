using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Furniture : MonoBehaviour
{
    public FurnitureState fState;
    public Renderer r;
    public Collider col;
    private List<Collider> cols = new List<Collider>();
    public RaycastHit surface;
    public bool IsColliding
    {
        get { return cols.Count >0; }
    }

    private void Awake()
    {
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        cols.Add(other);
    }
    private void OnTriggerExit(Collider other)
    {
        cols.Remove(other);
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
