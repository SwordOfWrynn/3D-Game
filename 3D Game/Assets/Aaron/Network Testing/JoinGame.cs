using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class JoinGame : MonoBehaviour {

    List<GameObject> roomList = new List<GameObject>();
    private NetworkManager networkManager;
    [SerializeField]
    private Text statusText;
    [SerializeField]
    private GameObject roomListItemPrefab;
    [SerializeField]
    private Transform roomListParent;

    private void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }

        RefreshRoomList();
    }

    public void RefreshRoomList()
    {
        networkManager.matchMaker.ListMatches(0, 10, "", true, 0, 0, OnMatchList);
        statusText.text = "Loading...";
    }

    public void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList)
    {
        statusText.text = "";
        if (matchList == null)
        {
            statusText.text = "Failed to get rooms.";
            return;
        }
        ClearRoomList();
        foreach(MatchInfoSnapshot match in matchList)
        {
            GameObject roomListItemGO = Instantiate(roomListItemPrefab);
            roomListItemGO.transform.SetParent(roomListParent);

            roomList.Add(roomListItemGO);
        }
        if (roomList.Count == 0)
        {
            statusText.text = "No active rooms";
        }
    }

    void ClearRoomList()
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            Destroy(roomList[i]);
        }
        roomList.Clear();
    }

}
