using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingSurface : MonoBehaviour
{
    public Vector3 cuttingPosition;

    private void Start()
    {
        cuttingPosition = transform.position + transform.up * 1.5f;
    }

    private bool breadOnBoard = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Bread")
        {
            breadOnBoard = true;
        }
    }

    public bool IsBreadOnCuttingBoard(GameObject bread)
    {

        return breadOnBoard;
    }
}
