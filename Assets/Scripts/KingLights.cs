using UnityEngine;

public class KingLights : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Light>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Light>().enabled = true;
        }
    }
}
