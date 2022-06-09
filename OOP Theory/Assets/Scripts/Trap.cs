using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public Material trapOrange;
    public Material trapBlue;
    public Material playerOrange;
    public Material playerBlue;

    public Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        GameManager.PlayerKilled += OnPlayerKilled;
    }

    private void OnDisable()
    {
        GameManager.PlayerKilled -= OnPlayerKilled;
    }

    public void OnPlayerKilled()
    {
        SetTrapMat();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (rend.sharedMaterial != other.gameObject.GetComponent<Renderer>().sharedMaterial)
            {
                StartCoroutine(GameManager.instance.ResetPlayer(other.gameObject));
                Debug.Log("asd");
            }
        }
    }

    private void SetTrapMat()
    {
        if (rend.sharedMaterial == trapOrange)
        {
            rend.material = trapBlue;
        }
        else
        {
            rend.material = trapOrange;
        }
    }
}
