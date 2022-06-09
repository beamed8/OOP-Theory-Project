using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePaint : Paint
{
    public Material bluePaintMat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PaintObject(other.gameObject, bluePaintMat);
        }
    }
}
