using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class RoomListItem : MonoBehaviour {

    public delegate void JoinRoomDelegate(MatchInfoSnapshot matchInfo);
    private JoinRoomDelegate joinRoomCallback;

    [SerializeField]
    private Text roomNameText;

	private MatchInfoSnapshot matchInfo;
    
    public void SetUp(MatchInfoSnapshot match, JoinRoomDelegate _joinRoomCallback)
    {
        matchInfo = match;
        joinRoomCallback = _joinRoomCallback;
        roomNameText.text = matchInfo.name + " (" + matchInfo.currentSize + "/" + matchInfo.maxSize + ") ";
    }

    public void JoinRoom()
    {
        joinRoomCallback.Invoke(matchInfo);
    }

}
