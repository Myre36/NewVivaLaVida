using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    //To make sure there are never more than two cameras
    private static CameraScript instance;

    //A refrence to the player's transform
    public Transform player;

    //A value for the speed which the camera moves at
    public float smoothSpeed = 5f;
    //The offset values of the camera to the player
    public float cameraZOffsetMin = -5.58f;
    public float cameraZOffsetMax = -8.25f;
    //For getting the vertical input of the player
    private float verticalInput;

    //The offset of the camera compared to the player
    public Vector3 offset;
    //The minimum and maximum camera positions possible
    public Vector3 minCamPosition;
    public Vector3 maxCamPosition;


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

    private void Update()
    {
        //Gets the vertical input
        verticalInput = Input.GetAxisRaw("Vertical");

        //The below code is to make sure the camera gets destroyed in certain scenes
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "TutorialScene")
        {
            Destroy(this.gameObject);
        }
        if(currentScene.name == "Death scene")
        {
            Destroy(this.gameObject);
        }

        //When the player is going towards the camera, the camera will move away from them until it hits the maximum distance to the player
        if (verticalInput < 0)
        {
            if(offset.z > cameraZOffsetMax)
            {
                offset.z -= 2f * Time.deltaTime;
            }
        }
        //When the player is moving away from the camera, the camera will move towards the camera until it hits the minimum distance to the player
        else if(verticalInput > 0)
        {
            if (offset.z < cameraZOffsetMin)
            {
                offset.z += 2f * Time.deltaTime;
            }
        }
    }

    //Code for moving the camera. The reason its in LateUpdate is because we want the camera to be a little bit behind the player
    private void LateUpdate()
    {
        //Gets the offset position from the player
        Vector3 desiredPosition = player.position + offset;

        //Clamps the position of the camera
        Vector3 clampedPosition = new Vector3(Mathf.Clamp(desiredPosition.x, minCamPosition.x, maxCamPosition.x), Mathf.Clamp(desiredPosition.y, minCamPosition.y, maxCamPosition.y), Mathf.Clamp(desiredPosition.z, minCamPosition.z, maxCamPosition.z));

        //Smoothly moves the camera to where it is supposed to be
        Vector3 smoothPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed * Time.deltaTime);

        //Moves the camera to the desired position
        transform.position = smoothPosition;
    }

    //This is old code, kept here for the sake of showing at the end of the project
    /*public float cameraMaximumZPosition;

    private float cameraOffsetValueMinimum;
    private float cameraOffsetValueMaximum;

    private void Update()
    {
        if(transform.position.z >= cameraMaximumZPosition)
        {
            cameraOffsetValueMinimum = -5.8f;
            cameraOffsetValueMaximum = -8.25f;

            if (Input.GetKey(KeyCode.S))
            {
                if (GetComponent<CinemachineFollow>().FollowOffset.z > cameraOffsetValueMaximum)
                {
                    GetComponent<CinemachineFollow>().FollowOffset.z -= 2f * Time.deltaTime;
                }
            }
            else if (Input.GetKey(KeyCode.W))
            {
                if (GetComponent<CinemachineFollow>().FollowOffset.z < cameraOffsetValueMinimum)
                {
                    GetComponent<CinemachineFollow>().FollowOffset.z += 2f * Time.deltaTime;
                }
            }
        }
        else
        {
            cameraOffsetValueMinimum = -4.96f;
            cameraOffsetValueMaximum = -8.25f;

            if (Input.GetKey(KeyCode.S))
            {
                if (GetComponent<CinemachineFollow>().FollowOffset.z < cameraOffsetValueMinimum)
                {
                    GetComponent<CinemachineFollow>().FollowOffset.z += 4f * Time.deltaTime;
                }
            }
            else if (Input.GetKey(KeyCode.W))
            {
                if (GetComponent<CinemachineFollow>().FollowOffset.z < cameraOffsetValueMinimum)
                {
                    GetComponent<CinemachineFollow>().FollowOffset.z += 2f * Time.deltaTime;
                }
            }
        }
    }*/
}
