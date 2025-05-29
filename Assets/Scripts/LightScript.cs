using UnityEngine;

public class LightScript : MonoBehaviour
{
    public int candleNum;

    public GameManager gameManager;

    [SerializeField] private AudioSource igniteSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Light fire = GetComponent<Light>();

        if (gameManager.candleStates[candleNum] == true)
        {
            fire.enabled = true;
        }
        else
        {
            fire.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Light fire = GetComponent<Light>();
        if (other.CompareTag("Player"))
        {
            if (fire.enabled == false) 
            {
                fire.enabled = true;
                igniteSound.Play();

                gameManager.candleStates[candleNum] = true;
            }
            
            

            
        }
    }
}
