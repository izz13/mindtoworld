using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOven : MonoBehaviour
{
    [SerializeField]
    GameObject openedOven;

    [SerializeField]
    GameObject closedOven;

    [SerializeField]
    OvenCollider oc;

  

    void Start()
    {
        openedOven.SetActive(false);
        closedOven.SetActive(true);
    }

    void Update()
    {

    }
    public void OpenOvenDoor()
    {
        openedOven.SetActive(true);
        closedOven.SetActive(false);
    }
    public void ClosedDoor()
    {
        openedOven.SetActive(false);
        closedOven.SetActive(true);
    }

    public bool isOpen()
    {
        if (openedOven.activeSelf) {
            return true;
        }
        else
        {
            return false;
        }

    }
}
