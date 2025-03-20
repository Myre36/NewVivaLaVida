using UnityEngine;

public class DetermineController : MonoBehaviour
{
    private static DetermineController instance;

    public bool usingController;

    private void Awake()
    {
        //This code is used to make sure there are never more than one game manager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
