using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Referece to other objects
    public Button AppQuit;
    public Text AILeft;
    public Text AIRight;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Set AI status
        AILeft.text = $"AI Left: {(AISettings.AILeftEnable ? "On" : "Off")}";
        AIRight.text = $"AI Right: {(AISettings.AIRightEnable ? "On" : "Off")}";
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

    /// <summary>
    /// Change AI settings
    /// </summary>
    /// <param name="sender">"Left" or "Right"</param>
    public void AIChange_Click(string sender)
    {
        if (sender == "Left")
        {
            AISettings.AILeftEnable = !AISettings.AILeftEnable;
            AILeft.text = $"AI Left: {(AISettings.AILeftEnable ? "On" : "Off")}";
        }
        else if (sender == "Right")
        {
            AISettings.AIRightEnable = !AISettings.AIRightEnable;
            AIRight.text = $"AI Right: {(AISettings.AIRightEnable ? "On" : "Off")}";
        }
    }
}

/// <summary>
/// Contain static information if the AIs are enabld or not
/// </summary>
public static class AISettings
{
    // Variables
    public static bool AILeftEnable = false;
    public static bool AIRightEnable = false;
}
