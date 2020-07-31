using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameSession gameSession;
    Vector3 startingCarPosition = new Vector3(0, -4, -1);
    Vector3 startingCarRotation = new Vector3(0, 0, 90);

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        Instantiate(gameSession.GetCar(), startingCarPosition, Quaternion.Euler(startingCarRotation));
    }
}
