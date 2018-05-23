using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenuEmpty;
    public GameObject lobbyMenu;
    bool mainMenuOn = true;
    public Button lobby2;
    public Button lobby3;
    public Button lobby4;
    private int levels;

    private void Start()
    {
        if (mainMenuEmpty == null)
            Debug.LogError("I don't know what's wrong");
		Cursor.lockState = CursorLockMode.None;
        mainMenuEmpty.SetActive(true);
		lobby2.interactable = false;
		lobby3.interactable = false;
		lobby4.interactable = false;
        if (levels >= 1)
          lobby2.interactable = true;
        if (levels >= 2)
          lobby3.interactable = true;
        if (levels >= 3)
          lobby4.interactable = true;
        lobbyMenu.SetActive(false);
      
    }

    public void SwitchMenu()
    {
        mainMenuEmpty.SetActive(!mainMenuEmpty.activeSelf);
        lobbyMenu.SetActive(!lobbyMenu.activeSelf);
        /*if (mainMenuOn)
        {
            Debug.Log(mainMenuEmpty);
            Debug.Log(lobbyMenu);
            lobbyMenu.SetActive(true);
            mainMenuEmpty.SetActive(false);
            mainMenuOn = false;
            
        }
        if (!mainMenuOn)
        {
            mainMenuEmpty.SetActive(true);
            lobbyMenu.SetActive(false);
            mainMenuOn = true;
        }*/
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

    public void GoToLobby1()
    {
        SceneManager.LoadScene("LobbyAtm1");
    }

    public void GoToLobby2()
    {
        SceneManager.LoadScene("Lobby1");
    }

    public void GoToLobby3()
    {
        SceneManager.LoadScene("Lobby2");
    }

    public void GoToLobby4()
    {
        SceneManager.LoadScene("Lobby3");
    }

    public void LoadLevels()
    {
        if (File.Exists(Application.persistentDataPath + "/Levels.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Levels.dat", FileMode.Open);
            LevelsInfo myLoadedInfo = (LevelsInfo)bf.Deserialize(file);
            levels = myLoadedInfo.levels;
        }
    }
}
