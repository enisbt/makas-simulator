using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Mute()
    {
        if (FindObjectOfType<AudioSource>().volume == 0.1f)
        {
            FindObjectOfType<AudioSource>().volume = 0;
        }
        else
        {
            FindObjectOfType<AudioSource>().volume = 0.1f;
        }
    }
}
