﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using System.Collections;

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
        ClearRoomList();

        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }

        networkManager.matchMaker.ListMatches(0, 10, "", true, 0, 0, OnMatchList);
        statusText.text = "Loading...";
    }

    public void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList)
    {
        statusText.text = "";
        if (!success || matchList == null)
        {
            statusText.text = "Failed to get rooms.";
            return;
        }

        foreach (MatchInfoSnapshot match in matchList)
        {
            GameObject roomListItemGO = Instantiate(roomListItemPrefab);
            roomListItemGO.transform.SetParent(roomListParent);

            RoomListItem roomListItem = roomListItemGO.GetComponent<RoomListItem>();
            if (roomListItem != null)
                roomListItem.SetUp(match, JoinRoom);

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

    public void JoinRoom (MatchInfoSnapshot matchInfo)
    {
        networkManager.matchMaker.JoinMatch(matchInfo.networkId, "", "", "", 0, 0, networkManager.OnMatchJoined);
        StartCoroutine(WaitForJoin());
    }

    IEnumerator WaitForJoin()
    {
        ClearRoomList();


        int countDown = 10;
        while (countDown > 0)
        {
            statusText.text = "Joining Game... (" + countDown + ")";
            yield return new WaitForSeconds(1f);
            countDown--;
        }

        statusText.text = "Failed to connect.";

        yield return new WaitForSeconds(1f);

        MatchInfo matchInfo = networkManager.matchInfo;
        if (matchInfo != null)
        {
            networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, networkManager.OnDropConnection);
            networkManager.StopHost();
        }
        RefreshRoomList();
    }

}
