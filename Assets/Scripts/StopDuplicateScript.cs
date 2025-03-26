using UnityEngine;

public class StopDuplicateScript : MonoBehaviour
{
    //This is just to prevent things from duplicating

    private static StopDuplicateScript instance;

    private void Awake()
    {
        //This code is used to make sure there are never more than one camera
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
