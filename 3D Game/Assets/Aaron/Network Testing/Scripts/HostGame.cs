using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HostGame : MonoBehaviour {
    
    private uint roomSize = 2;
    private string roomName;
    private NetworkManager networkManager;
    private string privateClietAddress = "1";

    public InputField inputField;
    public Button defaultButton;

    public void SetRoomName (string name)
    {
        roomName = name;
    }
    void Start ()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }
        inputField = GameObject.Find("RoomNameInputField").GetComponent<InputField>();
        defaultButton = GameObject.Find("Button").GetComponent<Button>();
    }
    public void CreateRoom()
    {
        if (roomName != "" && roomName != null)
        {
            Debug.Log("Creating Room: " + roomName);
            networkManager.matchMaker.CreateMatch(roomName, roomSize, true, "", "", "", 0, 0, networkManager.OnMatchCreate);
        }
        else
            Debug.LogError("The name " + roomName + " is not valid");
    }

	public void DefaultNames()
    {
        Debug.Log("Foo");
        defaultButton.Select();
    }

    public void SetName()
    {
        Debug.Log("Foo");
        inputField.text = "defaultName";
    }
	
}
