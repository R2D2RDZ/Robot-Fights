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
}
