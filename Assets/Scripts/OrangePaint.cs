using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangePaint : Paint
{
    public Material orangePaintMat;
    public GameObject orangeParticles;

    // POLYMORPHISM: override derived class' method to add another feature
    public override void PaintObject(GameObject toPaint, Material paintMaterial)
    {
        toPaint.GetComponent<Renderer>().material = paintMaterial;
        AddParticles(toPaint);
    }

    private void AddParticles(GameObject toAdd)
    {
        Instantiate(orangeParticles, toAdd.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PaintObject(other.gameObject, orangePaintMat);
        }
    }
}
