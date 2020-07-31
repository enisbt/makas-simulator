using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float moveSpeed = 2.5f;
    EnemySpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaY = Time.deltaTime * moveSpeed;
        var newYPos = transform.position.y - deltaY;
        transform.position = new Vector3(transform.position.x, newYPos, -1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Shredder")
        {
            Destroy(gameObject);
        }
    }
}
