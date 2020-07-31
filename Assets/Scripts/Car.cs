using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float padding = 2f;
    int score = 0;
    Level level;
    float xMax;
    float xMin;


    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
        level = FindObjectOfType<Level>();
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Game")
        {
            StartCoroutine(IncreaseScore());
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (SceneManager.GetActiveScene().name == "Start Screen")
        {

        }
        else
        {
            var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

            var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
            transform.position = new Vector3(newXPos, transform.position.y, -1);
        }
        
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }

    public void RemoveCar()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<GameSession>().SetAlive(false);
        level.LoadEndScreen();
    }

    IEnumerator IncreaseScore()
    {
        while (true)
        {
            score += 1;
            yield return new WaitForSeconds(.5f);
        }
    }

    public int GetScore()
    {
        return score;
    }
}
