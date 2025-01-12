using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadSlice : MonoBehaviour
{
    public bool isSliced;

    private void Start()
    {
        isSliced = false;

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Knife")
        {
            isSliced = true;
        }

        else
        {
            isSliced = false;
        }
    }
}
