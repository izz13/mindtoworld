using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
}
