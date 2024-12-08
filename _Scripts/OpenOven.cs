using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOven : MonoBehaviour
{
    [SerializeField]
    GameObject openedOven;

    [SerializeField]
    GameObject closedOven;

    void Start()
    {
        openedOven.SetActive(false);
        closedOven.SetActive(true);
    }

    public void HandlePressed()
    {
        openedOven.SetActive(true);
        closedOven.SetActive(false);
    }
}
