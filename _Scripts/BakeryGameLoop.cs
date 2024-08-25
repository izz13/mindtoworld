using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeryGameLoop : MonoBehaviour
{
    enum Breadtype { Wheat, Baguette, Bun, SourDough, Croissant };

    enum Breadsize { Small, Medium, Big };

    enum Breadcut { Thin, Thick, NoCut };

    Breadtype ChooseBreadtype()
    {
        int BreadtypeCount = 5;
        int RandomInt = Random.Range(0, BreadtypeCount);
        if (RandomInt == 0)
            return Breadtype.Wheat;
        else if (RandomInt == 1)
            return Breadtype.Baguette;
        else if (RandomInt == 2)
            return Breadtype.Bun;
        else if (RandomInt == 3)
            return Breadtype.SourDough;
        else
            return Breadtype.Croissant;
    }

    private void Start()
    {
        Debug.Log(ChooseBreadtype());
    }

}
