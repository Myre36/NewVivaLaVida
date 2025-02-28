using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    [SerializeField] private GameObject FirstFloorMap;
    [SerializeField] private GameObject SecondFloorMap;
    [SerializeField] private Transform player;

    public bool IsMapOpen { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        CloseFirstFloorMap();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (IsMapOpen)
            {
                OpenMap();
            }
            else
            {
                CloseFirstFloorMap();
            }
        }
    }

    private void OpenMap()
    {
        FirstFloorMap.SetActive(true);
        IsMapOpen = true;
    }


    private void CloseFirstFloorMap()
    {
        FirstFloorMap.SetActive(false);
        IsMapOpen = false;
    }
}