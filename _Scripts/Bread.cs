using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : MonoBehaviour
{
    public BakeryGameLoop.Breadtype type;

    public Vector3 startPos;

    private void Start()
    {
        resetPos();
    }

    public void resetPos()
    {
        transform.position = startPos;
    }

    //public Vector3 ResetPos()
    //{
    //    return startPos.position;
    //}
}
