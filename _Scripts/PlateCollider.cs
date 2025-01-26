using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCollider : MonoBehaviour
{
    bool hasBread;

    private void Start()
    {
        hasBread = false;
    }

    public bool getHasBread()
    {
        return hasBread;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Bread")
        {
            hasBread = true;
        }
        
    }
}
