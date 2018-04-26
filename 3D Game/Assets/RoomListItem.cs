using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class RoomListItem : MonoBehaviour {

    [SerializeField]
    private Text roomNameText;

	private MatchInfoSnapshot matchInfo;
    
    public void SetUp(MatchInfoSnapshot match)
    {
        matchInfo = match;

        roomNameText.text = matchInfo.name + " (" + matchInfo.currentSize + "/" + matchInfo.maxSize + ") ";
    }

}
