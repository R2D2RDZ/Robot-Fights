using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScenes : MonoBehaviour
{
    public void ChangeToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ChangeToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void ChangeToEditor()
    {
        SceneManager.LoadScene("RobotEditor");
    }
    public void ChangeToGame()
    {
        SceneManager.LoadScene("Ring");
    }

    public static void ChangeMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public static void ChangeLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
    public static void ChangeEditor()
    {
        SceneManager.LoadScene("RobotEditor");
    }
    public static void ChangeGame()
    {
        SceneManager.LoadScene("Ring");
    }
}
