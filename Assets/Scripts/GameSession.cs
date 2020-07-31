using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] GameObject selectedCar;
    [SerializeField] int score;
    [SerializeField] bool alive = true;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int modifier;
    Car playerCar;

    void Awake()
    {
        int gameSessionCount = FindObjectsOfType<GameSession>().Length;
        if (gameSessionCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            playerCar = FindObjectOfType<Car>();
            score = playerCar.GetScore();
        }
        if (SceneManager.GetActiveScene().name != "Start Screen")
        {
            FindObjectOfType<ScoreDisplay>().SetScoreText(score);
        }
    }

    public void SetCar(GameObject car)
    {
        selectedCar = car;
    }

    public GameObject GetCar()
    {
        return selectedCar;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetModifier(int modifier)
    {
        this.modifier = modifier;
    }

    public bool IfAlive()
    {
        return alive;
    }

    public void SetAlive(bool alive)
    {
        this.alive = alive;
    }
}
