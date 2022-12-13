using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Set variables
    private readonly float MaxHeight = 5.8f;
    private readonly float MinHeight = -5.8f;
    public float PlayerSpeed;
    public KeyCode KeyUp;
    public KeyCode KeyDown;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Set to start position
        transform.position = new Vector2(transform.position.x, 0);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Move player up
        if (Input.GetKey(KeyUp))
        {
            if (!(transform.position.y >= MaxHeight))
                transform.position = new Vector2(transform.position.x, transform.position.y + PlayerSpeed);
        }

        // Move player down
        else if (Input.GetKey(KeyDown))
        {
            if(!(transform.position.y <= MinHeight))
                transform.position = new Vector2(transform.position.x, transform.position.y - PlayerSpeed);
        }
    }
}
