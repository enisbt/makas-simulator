using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.8f;
    Material background;
    Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Renderer>().material;
        offset = new Vector2(0f, scrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2(0f, scrollSpeed);
        background.mainTextureOffset += offset * Time.deltaTime;
    }

    public float GetScrollSpeed()
    {
        return scrollSpeed;
    }

    public void IncreaseScrollSpeed()
    {
        if (scrollSpeed >= 1f)
        {
            scrollSpeed = 1f;
        }
        else
        {
            scrollSpeed = scrollSpeed * 1.0005f;
        }
    }

    public void StopScrolling()
    {
        scrollSpeed = 0f;
    }
}
