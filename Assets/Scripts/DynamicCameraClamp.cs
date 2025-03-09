using UnityEngine;

public class DynamicCameraClamp : MonoBehaviour
{
    //The room's maximum and minimum camera clamps
    public Vector3 cameraClampMin;
    public Vector3 cameraClampMax;

    //A refrence to the camera script
    private CameraScript playerCamera;

    //A bool for if the camera should change its height
    public bool changesHeight;

    //The new height at which the camera should be in
    public float yOffsetChange;

    private void Start()
    {
        //Assigning the camera script
        playerCamera = GameObject.Find("Main Camera").GetComponent<CameraScript>();
    }

    private void OnTriggerStay(Collider other)
    {
        //If the player enters the trigger, the clamped position of the camera will change
        if(other.CompareTag("Player"))
        {
            playerCamera.minCamPosition = cameraClampMin;
            playerCamera.maxCamPosition = cameraClampMax;
            //If the camera is supposed to change its height, it will do so when the player enters the trigger
            if(changesHeight)
            {
                playerCamera.offset.y = yOffsetChange;
            }
        }
    }
}
