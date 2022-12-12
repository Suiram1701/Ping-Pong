using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    // Referece to other objects
    public Button AppQuit;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// Load game scene
    /// </summary>
    public void GameStart_Click()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// The event handler for the AppQuit button
    /// </summary>
    public void AppQuit_Click()
    {
        Application.Quit();
    }
}
