using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	
    public void GoToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void GoToAchievments()
    {
        SceneManager.LoadScene("Achievments");
    }


    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
