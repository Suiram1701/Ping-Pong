using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class Player : MonoBehaviour
{
    // Reference to other objects
    public Ball Ball;

    // Set variables
    private readonly float MaxHeight = 5.8f;
    private readonly float MinHeight = -5.8f;
    public bool isAI;
    public float AITolerence;
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
        if (!isAI)
        {
            // Move player up
            if (Input.GetKey(KeyUp))
            {
                if (!(transform.position.y >= MaxHeight))
                    transform.position = new Vector2(transform.position.x, transform.position.y + PlayerSpeed * Time.deltaTime);
            }
    
            // Move player down
            else if (Input.GetKey(KeyDown))
            {
               if(!(transform.position.y <= MinHeight))
                    transform.position = new Vector2(transform.position.x, transform.position.y - PlayerSpeed * Time.deltaTime);
            }
        }
        else
        {
            switch (CalcTargetPos())
            {
                case -1:
                    if (!(transform.position.y <= MinHeight))
                        transform.position = new Vector2(transform.position.x, transform.position.y - PlayerSpeed * Time.deltaTime);
                    break;
                case 0:
                    break;
                case 1:
                    if (!(transform.position.y >= MaxHeight))
                        transform.position = new Vector2(transform.position.x, transform.position.y + PlayerSpeed * Time.deltaTime);
                    break;
            }
        }
    }

    /// <summary>
    /// Calculate if the must move up / down or not move to catch the ball
    /// </summary>
    /// <returns>-1 if Move down, 0 if no move, 1 if move up</returns>
    int CalcTargetPos()
    {
        Vector2 ballPos = Ball.transform.position;
        Vector2 paddlePos = transform.position;

        /*if ((ballPos.y <= paddlePos.y + AITolerence) && (ballPos.y >= paddlePos.y - AITolerence))
        {
            Debug.Log("AI0");
            return 0;
        }*/
        if (ballPos.y < paddlePos.y)
        {
            Debug.Log("AI1");
            return 1;
        }
        else if (ballPos.y > paddlePos.y)
        {
            Debug.Log("AI-1");
            return -1;
        }

        return 0;
    }
}
