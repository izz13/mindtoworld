using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//The Steps For Making Bread i.e. the game states we want or game to be
//1. Read the instructions for the type of bread to make, gameState : readInstructions
//2. Get the correct dough type for breadtype and size, gameState : collectBread
//3. Put the dough in the oven to bake, gameState : bakeBread
//4. Take out the bread and put it on the cutting board, gameState : placeBread
//5. Cut the bread according the breadcut size requested, gameState : cutBread
//6. Put it on a finishing plate/bag to finish bread making process, gameState : finishBread
//7. Collect reward for making the bread, gameState : collectReward
//8. Go back to step 1


public class BakeryGameLoop : MonoBehaviour
{
    enum Breadtype { Wheat, Baguette, Bun, SourDough, Croissant };

    enum Breadsize { Small, Medium, Big };

    enum Breadcut { Thin, Thick, NoCut };

    enum GameStates {readInstructions ,collectBread, bakeBread, placeBread, cutBread, finishBread, collectReward};

    GameStates currentState;

    [SerializeField]
    TextMeshProUGUI instructionText;

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
        currentState = GameStates.readInstructions;
        
    }
    private void Update()
    {
        //Make a switch case to handle the different states of the game
        switch (currentState)
        {
            case GameStates.readInstructions:
                currentState = readInstructions();
                break;
        }
    }

    GameStates readInstructions()
    {
        return GameStates.readInstructions;
    }

    Breadsize ChooseBreadsize()
    {
        int BreadsizeCount = 3;
        int RandomInt = Random.Range(0, BreadsizeCount);
        if (RandomInt == 0)
            return Breadsize.Small;
        else if (RandomInt == 1)
            return Breadsize.Medium;
        else if (RandomInt == 2)
            return Breadsize.Big;
        else
            return Breadsize.Small;
    }

    Breadcut ChooseBreadcut()
    {
        int BreadcutCount = 3;
        int RandomInt = Random.Range(0, BreadcutCount);
        if (RandomInt == 0)
            return Breadcut.Thin;
        else if (RandomInt == 1)
            return Breadcut.Thick;
        else
            return Breadcut.NoCut;

    }

}
