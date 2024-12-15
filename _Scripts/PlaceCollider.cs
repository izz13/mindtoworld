using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCollider : MonoBehaviour
{
    public string objectName = "";
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        objectName = other.gameObject.name;
    }
}
