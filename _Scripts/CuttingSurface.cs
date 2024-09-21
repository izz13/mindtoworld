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
}
