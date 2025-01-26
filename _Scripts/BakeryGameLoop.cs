using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

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
    public enum Breadtype { Wheat, Baguette, Bun, SourDough, Croissant };

    enum Breadsize { Small, Medium, Big };

    enum Breadcut { Thin, Thick, NoCut };

    public enum GameStates {readInstructions ,collectBread, bakeBread, placeBread, cutBread, finishBread, collectReward};

    public GameStates currentState;

    float bakeTimer = 0f;

    float bakeCooldown = 3f;

    Breadtype currentType;

    Breadsize currentSize;

    Breadcut currentCut;

    ReadInstructions readInstructions;

    [SerializeField]
    GameObject canvas;

    [SerializeField]
    TextMeshProUGUI instructionText;

    [SerializeField]
    GameObject CuttingBoard;
    CuttingSurface cuttingSurface;

    [SerializeField]
    InputActionMap actionManager;

    [SerializeField]
    GameObject okButton;

    [SerializeField]
    GameObject nextMenuButton;
    
    [SerializeField]
    PlaceCollider pc;

    [SerializeField]
    OpenOven openOven;

    [SerializeField]
    BakeCollider bakeCollider;

    [SerializeField]
    BreadSlicing breadSlicing;

    [SerializeField]
    Transform slicingBreadPrefab;

    [SerializeField]
    Transform platePrefab;

    PlateCollider plateCollider;

    GameObject heldBread;

<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
    bool hasPlateSpawned = false;
=======
    bool hasPlateSpawned = false;

>>>>>>> Stashed changes


>>>>>>> Stashed changes
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
        cuttingSurface = CuttingBoard.GetComponent<CuttingSurface>();
        setParameters();
        
    }
    private void Update()
    {
        //Make a switch case to handle the different states of the game
        switch (currentState)
        {
            case GameStates.readInstructions:
                currentState = readInstruct();
                break;
            case GameStates.collectBread:
                currentState = collectBread();
                break;
            case GameStates.bakeBread:
                currentState = bakeBread();
                break;
            case GameStates.placeBread:
                currentState = placeBread();
                break;
            case GameStates.cutBread:
                currentState = cutBread();
                break;
<<<<<<< Updated upstream
=======
            case GameStates.finishBread:
                currentState = finishBread();
                break;
            case GameStates.collectReward:
                currentState = collectReward();
                break;
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        }
    }

    GameStates readInstruct()
    {
        //okButton.SetActive(true);
        //nextMenuButton.SetActive(true);
        displayInstructions();
        return GameStates.readInstructions;
    }

    GameStates collectBread()
    {
        okButton.SetActive(false);
        nextMenuButton.SetActive(false);
        
        if (pc.objectName == currentType.ToString())
        {
            instructionText.SetText("You placed the correct bread.");
            openOven.OpenOvenDoor();
            heldBread = pc.bread;
            return GameStates.bakeBread;
        }
        else if (pc.objectName == "")
        {
            instructionText.SetText("Please select bread " + currentType.ToString());
            return GameStates.collectBread;
        }
        else
        {
            instructionText.SetText("You placed the wrong bread");
            return GameStates.collectBread;
        }
    }

    GameStates bakeBread()
    {
        instructionText.SetText("Please put bread in oven.");
        if (bakeCollider.objectName == currentType.ToString())
        {
            if (bakeTimer < bakeCooldown)
            {
                if (bakeTimer <= 0f)
                {
                    openOven.ClosedDoor();
                    heldBread.SetActive(false);

                }
                bakeTimer += Time.deltaTime;
                int countDown = Mathf.CeilToInt(bakeCooldown - bakeTimer);
                instructionText.SetText(countDown.ToString());
                return GameStates.bakeBread;

            }
            else
            {
                Bread bread = heldBread.GetComponent<Bread>();
                Rigidbody breadRB = heldBread.GetComponent<Rigidbody>();
                breadRB.velocity = new Vector3(0f, 0f, 0f);
                Vector3 sPos = bread.startPos;
                heldBread.transform.position = sPos;
                heldBread.SetActive(true);
                bakeTimer = 0f;
                return GameStates.placeBread;
            }

            
        }
        return GameStates.bakeBread;
    }

    GameStates placeBread()
    {
        instructionText.SetText("Please place bread on cutting table");
        if (!openOven.isOpen())
        {
            openOven.OpenOvenDoor();
            Transform br = Instantiate(slicingBreadPrefab);
            br.position = openOven.gameObject.transform.position;
            br.position += br.up;
            br.position -= br.right;
        }
        
        return GameStates.placeBread;
    }

    void SpawnPlate()
    {
        Transform plate = Instantiate(platePrefab);
        GameObject placeTable = GameObject.FindGameObjectWithTag("PlaceTable");
        plateCollider = plate.gameObject.GetComponentInChildren<PlateCollider>();
        if (placeTable != null)
        {
            Vector3 placePosition = placeTable.transform.position;
            plate.transform.position = new Vector3(placePosition.x, placePosition.y+ 1, placePosition.z);
        }

    }

    GameStates cutBread()
    {
        instructionText.SetText("Please cut the bread");
<<<<<<< Updated upstream
        return GameStates.cutBread;
=======
        if (breadSlicing.getBreadSliced())
        {
            SpawnPlate();
            return GameStates.finishBread;
        }
        else
        {
            return GameStates.cutBread;

        }
    }

    GameStates finishBread()
    {
        instructionText.SetText("Please plate sliced bread");
        //if (!hasPlateSpawned)
        //{
        //    SpawnPlate();
        //    hasPlateSpawned = true;
        //}
        if (plateCollider.getHasBread())
        {
            return GameStates.collectReward;
        }
        else
        {
            return GameStates.finishBread;
        }
        
    }

    GameStates collectReward()
    {
        instructionText.SetText("Please place plate with bread at reward station to collect reward!!!");
        return GameStates.collectReward;
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }

    private void displayInstructions()
    {
        string BreadType = "Choose type: " + currentType.ToString();
        string BreadCut = "Choose cut: " + currentCut.ToString();
        string BreadSize = "Choose size: " + currentSize.ToString();
        string instrusctions = BreadType + "<br>" + BreadCut + "<br>" + BreadSize;
        instructionText.SetText(instrusctions);
    }

    public void setParameters()
    {
        currentType = ChooseBreadtype();
        currentSize = ChooseBreadsize();
        currentCut = ChooseBreadcut();
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

    public void ChangeGameState()
    {
        currentState ++;
    }

}
