using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    [SerializeField]
    private GameObject pauseMenu;
    public Button leaveGame;

	// Use this for initialization
	void Start () {
        PauseMenu.isOn = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
	}

    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        PauseMenu.isOn = pauseMenu.activeSelf;
        if (pauseMenu.activeSelf == true)
            leaveGame.Select();
    }
}
