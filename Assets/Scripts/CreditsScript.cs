using UnityEngine;
using System.Collections;
using UnityEngine.Video;

public class CreditsScript : MonoBehaviour
{
    public float scrollSpeed = 40f;

    private RectTransform rectTransform;

    private bool started;

    public int timeToCredits;

    public VideoPlayer cutscene;

    [SerializeField]
    private RectTransform endPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(StartCredits());
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if(rectTransform.anchoredPosition.y < endPoint.anchoredPosition.y)
            {
                rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
            }
        }
    }

    private IEnumerator StartCredits()
    {
        yield return new WaitForSeconds(timeToCredits);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cutscene.targetCameraAlpha = 0f;
        started = true;
    }
}