using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadSlicing : MonoBehaviour
{
    [SerializeField]
    GameObject slice1;

    [SerializeField]
    GameObject slice2;

    [SerializeField]
    GameObject breadLoaf;

    [SerializeField]
    GameObject breadSliced;

    public AudioSource audioSource;

    public bool isBreadSliced = false;

    int breadState = 0;

    // Start is called before the first frame update
    void Start()
    {
        //breadSliced.SetActive(false);
        //breadLoaf.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        BreadSlice S1 = slice1.GetComponent<BreadSlice>();
        BreadSlice S2 = slice2.GetComponent<BreadSlice>();

        if (S1.isSliced)
        {
            slice1.SetActive(false);
            audioSource.PlayOneShot(audioSource.clip, 0.5f);
        }

        if (S2.isSliced)
        {
            slice2.SetActive(false);
            audioSource.PlayOneShot(audioSource.clip, 0.5f);
        }

        if (S1.isSliced && S2.isSliced)
        {
        //    Debug.Log("bread is sliced");
            breadLoaf.SetActive(false);
            breadSliced.SetActive(true);
            isBreadSliced = true;
        }
    }

    public bool getBreadSliced()
    {
        return isBreadSliced;
    }
}