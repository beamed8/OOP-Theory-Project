using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangePaint : Paint
{
    public Material orangePaintMat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PaintObject(other.gameObject, orangePaintMat);
        }
    }
}
