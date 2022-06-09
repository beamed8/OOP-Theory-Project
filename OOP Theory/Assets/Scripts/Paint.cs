using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    public void PaintObject(GameObject toPaint, Material paintMaterial)
    {
        toPaint.GetComponent<Renderer>().material = paintMaterial;
    }

}