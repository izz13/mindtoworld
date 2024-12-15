using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenCollider : MonoBehaviour
{
    public bool ovenCollided = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "closed_handle")
        {
            ovenCollided = true;
        }

        //if (collision.gameObject.name == "opened_handle")
        //{
        //    ovenCollided = false;
        //}
    }
}