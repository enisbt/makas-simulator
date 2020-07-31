using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelector : MonoBehaviour
{
    [SerializeField] List<GameObject> cars;
    [SerializeField] GameSession gameSession;
    int carIndex = 0;
    int carsLength;
    Vector3 startingCarPosition = new Vector3(0, -4, -1);
    Vector3 startingCarRotation = new Vector3(0, 0, 90);

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        carsLength = cars.Count;
        InstantiateCar(0);
    }

    public void NextCar()
    {
        FindObjectOfType<Car>().RemoveCar();
        if (carIndex == carsLength - 1)
        {
            InstantiateCar(0);
            carIndex = 0;
        }
        else
        {
            InstantiateCar(carIndex + 1);
            carIndex += 1;
        }
    }

    public void PreviousCar()
    {
        FindObjectOfType<Car>().RemoveCar();
        if (carIndex == 0)
        {
            InstantiateCar(14);
            carIndex = 14;
        }
        else
        {
            InstantiateCar(carIndex - 1);
            carIndex -= 1;
        }
    }

    private void InstantiateCar(int index)
    {
        gameSession.SetCar(cars[index]);
        Instantiate(cars[index], startingCarPosition, Quaternion.Euler(startingCarRotation));
    }
}
