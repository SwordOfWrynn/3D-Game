using UnityEngine;
using UnityEngine.Networking;

public class HostGame : MonoBehaviour {
    
    private uint roomSize = 2;
    private string roomName;
    private NetworkManager networkManager;
    private string privateClietAddress = "1";

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
	}
    public void CreateRoom()
    {
        if (roomName != "" && roomName != null)
        {
            Debug.Log("Creating Room: " + roomName);
            networkManager.matchMaker.CreateMatch(roomName, roomSize, true, "", "", 0, 0, networkManager.OnMatchCreate);
        }
    }

	
	
	void Update () {
		
	}
}
