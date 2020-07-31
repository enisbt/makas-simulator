using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyCars;
    [SerializeField] GameSession gameSession;

    Vector3 leftmostLanePosition = new Vector3(-1.27f, 6f, -1f);
    Vector3 leftLanePosition = new Vector3(-0.42f, 6f, -1f);
    Vector3 rightLanePosition = new Vector3(0.42f, 6f, -1f);
    Vector3 rightmostLanePosition = new Vector3(1.27f, 6f, -1f);
    Vector3[] lanes;


    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();

        lanes = new Vector3[] {
            leftmostLanePosition,
            leftLanePosition,
            rightLanePosition,
            rightmostLanePosition
        };
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        int score = gameSession.GetScore();
    }

    IEnumerator SpawnEnemies()
    {
        while (gameSession.IfAlive())
        {
            int numberOfCars = Random.Range(1, 4);
            if (numberOfCars == 1)
            {
                int enemyIndex = Random.Range(0, enemyCars.Count);
                int laneIndex = Random.Range(0, lanes.Length);
                InstantiateEnemy(enemyIndex, laneIndex);
            }
            else if (numberOfCars == 2)
            {
                int leftLane = Random.Range(0, 2);
                int rightLane = Random.Range(2, 4);
                int firstCar = Random.Range(0, enemyCars.Count);
                int secondCar = Random.Range(0, enemyCars.Count);
                InstantiateEnemy(firstCar, leftLane);
                InstantiateEnemy(secondCar, rightLane);
            }
            else if (numberOfCars == 3)
            {
                int removeLane = Random.Range(0, lanes.Length);
                for (int i = 0; i < lanes.Length; i++)
                {
                    if (i != removeLane)
                    {
                        int enemyIndex = Random.Range(0, enemyCars.Count);
                        InstantiateEnemy(enemyIndex, i);
                    }

                }
            }
            yield return new WaitForSeconds(1.5f);
        }
    }

    private void InstantiateEnemy(int enemyIndex, int laneIndex)
    {
        Vector3 rotation;
        rotation = new Vector3(0, 0, 90);
        Instantiate(enemyCars[enemyIndex], lanes[laneIndex], Quaternion.Euler(rotation));
    }
}
