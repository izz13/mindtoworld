using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeryGameLoop : MonoBehaviour
{
    enum Breadtype { Wheat, Baguette, Bun, SourDough, Croissant };

    enum Breadsize { Small, Medium, Big };

    enum Breadcut { Thin, Thick, NoCut };

    enum ChooseBreadtype()
    {
        int BreadtypeCount = Breadtype.GetValues().Length;
        int RandomInt = Random.Range(0, BreadtypeCount);
        if (RandomInt == 0)
            return Breadtype.Wheat;
        else if (RandomInt == 1)
            return Breadtype.Baguette;
    }

}
