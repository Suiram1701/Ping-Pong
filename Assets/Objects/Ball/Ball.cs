using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using System.Threading;

public class Ball : MonoBehaviour
{
    // Reference to other objects
    public GUI GUI;

    // Init varibles for ball
    public float Speed;
    private float Direction = 1f;
    private bool isRight = true;
    public bool isTop = false;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        // Random start vector
        Direction = UnityEngine.Random.Range(0.50f, 0.85f);
        isTop = UnityEngine.Random.Range(0, 2) == 0;

        // Start at position zero
        transform.position = new Vector2(0, 0);

        // Set start speed
        Speed = 15f;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        // Move ball
        transform.position = new Vector2(transform.position.x + ((isRight ? Speed : - Speed) * Direction) * Time.deltaTime, transform.position.y);
        transform.position = new Vector2(transform.position.x, transform.position.y + (isTop ? (Speed - Speed * Direction) : - (Speed - Speed * Direction)) * Time.deltaTime);
    }

    /// <summary>
    /// Enter if a object collide with the ball
    /// </summary>
    /// <param name="collision">Object</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))  // Collide with a player
            Bounce(true);
        else if (collision.gameObject.CompareTag("TB")) // Collide with a wall (top or bottom)
            Bounce(false);
        else
        {
            if (!GUI.AddPoint(collision.gameObject.CompareTag("Pl1Wall")))
                gameObject.gameObject.SetActive(false);
            else
            {
                isRight = !collision.gameObject.CompareTag("Pl2Wall");
                Start();
            }
        }
    }

    /// <summary>
    /// Bounce ball
    /// </summary>
    /// <param name="Horizontal">true if ball will bounce from left to right (or reverse) and false if ball bounce from top to bottom (or reverse)</param>
    private void Bounce(bool Horizontal)
    {
        if (Horizontal)            // Bounce from left to right (or reverse)
        {
            isRight = !isRight;
            Speed = 30f;
        }

        else                       // Bounce from top to bottom (or reverse)
            isTop = !isTop;

        // Random move direction
        Direction = UnityEngine.Random.Range(Direction >= 0.45f ? 0.8f : 1f, Direction <= 0.90 ? 1.2f : 1f) * Direction;
        //Debug.Log(Direction);
    }
}
