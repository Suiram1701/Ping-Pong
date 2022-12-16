using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    // Reference to other objects
    public Text Points;
    public Text Panel;
    public Player Pl1;
    public Player Pl2;
    public Ball Ball;
    public Button MenuBtn;

    // Init variables
    public int MaxPoints;
    private int Pl1Points;
    private int Pl2Points;
    private bool Menu = false;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        Pl1Points = 0;
        Pl2Points = 0;
        Points.text = "0 : 0";
        Panel.text = "";
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Panel.text = Menu ? "Pause" : "";
            Ball.Speed = Menu ? 0f : 30f;
            Pl1.PlayerSpeed = Menu ? 0f : 15f;
            Pl2.PlayerSpeed = Menu ? 0f : 15f;
            MenuBtn.gameObject.SetActive(Menu);
            Menu = !Menu;
        }
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

        if (Pl1Points >= MaxPoints) // Check if a player1 Win
            SetPanel(1);
        else if (Pl2Points >= MaxPoints) // Check if a player1 Win
            SetPanel(2);
        else
            return true;

        ReturnLobby();
        return false;
    }

    /// <summary>
    /// Return to lobby with a delay
    /// </summary>
    public async void ReturnLobby()
    {
        await Task.Run(() =>
        {
            Thread.Sleep(2000);
            SceneManager.LoadScene(0);
        });
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

    /// <summary>
    /// Load menu
    /// </summary>
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}