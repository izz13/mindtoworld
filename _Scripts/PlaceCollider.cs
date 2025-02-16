using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCollider : MonoBehaviour
{
    public string objectName = "";
    public GameObject bread;
    public Bread br;

    public void OnTriggerEnter(Collider other)
    {

        objectName = other.gameObject.name;
        bread = other.gameObject;
        br = bread.GetComponent<Bread>();
    }

    public void ResetParts()
    {
        objectName = "";
        //bread = null;
        //br = null;
    }
}
