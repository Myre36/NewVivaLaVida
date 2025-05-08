using UnityEngine;

public class LightScript : MonoBehaviour
{
    private int candleNum;

    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (gameManager.candleStates[candleNum] == true)
        {
            GetComponent<Light>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GetComponent<Light>().enabled = true;
        }
    }
}
