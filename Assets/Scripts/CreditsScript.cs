using UnityEngine;
using System.Collections;

public class CreditsScript : MonoBehaviour
{
    public float scrollSpeed = 40f;

    private RectTransform rectTransform;

    private bool started;

    public int timeToCredits;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(StartCredits());
    }

    // Update is called once per frame
    void Update()
    {
        if(started)
        {
            rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
        }
    }

    private IEnumerator StartCredits()
    {
        yield return new WaitForSeconds(timeToCredits);
        started = true;
    }
}
