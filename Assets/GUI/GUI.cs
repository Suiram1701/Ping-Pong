using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    // Reference to other objects
    public Text Points;
    public Text Panel;

    // Init variables
    public int MaxPoints;
    private int Pl1Points;
    private int Pl2Points;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        Pl1Points = 0;
        Pl2Points = 0;
        Points.text = "0 : 0";
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// Add points for a player
    /// </summary>
    /// <param name="isPlayer1Wall">Is it player1Wall or not</param>
    /// <returns>if game end or not</returns>
    public bool AddPoint(bool isPlayer1Wall)
    {
        if (!isPlayer1Wall) // Add a player a point
            Pl1Points++;
        else
            Pl2Points++;

        Points.text = $"{Pl1Points} : {Pl2Points}"; // Update point display

        if (Pl1Points >= MaxPoints) // Check if a player Win
        {
            SetPanel(1);
            return false;
        }
        else if (Pl2Points >= MaxPoints)
        {
            SetPanel(2);
            return false;
        }
        else
            return true;
    }

    /// <summary>
    /// Set actions on the panel
    /// </summary>
    /// <param name="action">1 = Pl1 Win  2 = Pl2 Win</param>
    public void SetPanel(int action)
    {
        switch (action)
        {
            case 1:
                Panel.text = "<- Win!";
                break;
            case 2:
                Panel.text = "Win! ->";
                break;
        }
    }
}