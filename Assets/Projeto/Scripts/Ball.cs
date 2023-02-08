using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float minSpeed = 50.0f, maxSpeed = 100.0f, currentSpeed;
    public float difficultyMultiplier = 1.3f;
    private float playerHeight, playerY, angleY, distanceToCenter;
    private Vector2 direction;

    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        currentSpeed = minSpeed;

        direction.x = (float)Random.Range(-1, 2);
        while (direction.x == 0)
        {
            direction.x = (float)Random.Range(-1, 2);
        }

        direction.y = (float)Random.Range(-1, 2);
        while (direction.y == 0)
        {
            direction.y = (float)Random.Range(-1, 2);
        }

        angleY = Random.Range(0.0f, 5 * Mathf.PI / 12f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = rigidbody.position;

        position.x += direction.x * currentSpeed * Time.deltaTime;
        position.y += Mathf.Sin(direction.y * angleY) * currentSpeed * Time.deltaTime;

        rigidbody.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();

        if (collision.collider.tag == "Player")
        {
            playerHeight = collision.collider.GetComponent<BoxCollider2D>().size.y;
            playerY = collision.collider.transform.position.y;

            distanceToCenter = Mathf.Abs(playerY - transform.position.y);
            angleY = distanceToCenter / (playerHeight / 2) * (5 * Mathf.PI / 12);

            if (playerY > transform.position.y)
            {
                direction.y = -1;
            }
            else direction.y = 1;

            direction.x *= -1;



            currentSpeed *= difficultyMultiplier;

            if (currentSpeed > maxSpeed) currentSpeed = maxSpeed;
        } 
        else if (collision.collider.tag == "Border")
        {
            direction.y *= -1;
        }
    }
}
