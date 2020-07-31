using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncreaser : MonoBehaviour
{
    BackgroundScroller scroller;

    // Start is called before the first frame update
    void Start()
    {
        scroller = FindObjectOfType<BackgroundScroller>();
    }

    // Update is called once per frame
    void Update()
    {
        scroller.IncreaseScrollSpeed();
    }
}
