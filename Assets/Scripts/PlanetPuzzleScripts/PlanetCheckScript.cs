using UnityEngine;

public class PlanetCheckScript : MonoBehaviour
{
    //A bool for when all planets are in order
    public bool planetsInOrder;

    //An array of all the stands
    public GameObject[] stands;
    //A refrence to the key that will appear when the puzzle is solved
    public GameObject keyItem;

    //A refrence to the game manager
    private GameManager gameManager;

    private void Start()
    {
        //Assigning the game manager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if all stands have the correct planets placed on them
        if (stands[0].GetComponent<PanetPuzzleScript>().hasCorrectPlanet && stands[1].GetComponent<PanetPuzzleScript>().hasCorrectPlanet && stands[2].GetComponent<PanetPuzzleScript>().hasCorrectPlanet && stands[3].GetComponent<PanetPuzzleScript>().hasCorrectPlanet && stands[4].GetComponent<PanetPuzzleScript>().hasCorrectPlanet && stands[5].GetComponent<PanetPuzzleScript>().hasCorrectPlanet && stands[6].GetComponent<PanetPuzzleScript>().hasCorrectPlanet && stands[7].GetComponent<PanetPuzzleScript>().hasCorrectPlanet)
        {
            //Sets the bool to true
            planetsInOrder = true;
            //Goes through all stands and tells all of them that the puzzle has been solved
            for(int i = 0; i < stands.Length; i++)
            {
                var currentStand = stands[i].GetComponent<PanetPuzzleScript>();
                currentStand.puzzleOver = true;
                currentStand.playerInRange = false;
            }
        }
        //When the planets are in the correct order, the key is turned on and this script is deactivated
        if(planetsInOrder)
        {
            keyItem.SetActive(true);
            gameManager.planetSolved = true;
            this.enabled = false;
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < stands.Length; i++)
        {
            var currentStand = stands[i].GetComponent<PanetPuzzleScript>();

            if(currentStand.currentlyEnabledPlanet == null)
            {
                gameManager.stands[i] = "None";
            }
            else
            {
                gameManager.stands[i] = currentStand.currentlyEnabledPlanet.name;
            }
        }
    }
}
