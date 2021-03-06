﻿using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componentsToDisable;
    [SerializeField]
    private int remoteLayerNumber = 10;
    [SerializeField]
    private int dontDrawLayerNumber = 12;
    [SerializeField]
    GameObject playerGraphics;
    [SerializeField]
    GameObject playerUIPrefab;
    private GameObject playerUIInstance;
    private GameObject levelManager;
    private Text objText;

    private Camera sceneCamera;

    void Start()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssignRemotePlayer();
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null)
                sceneCamera.gameObject.SetActive(false);
            SetLayerRecursively(playerGraphics, dontDrawLayerNumber);
            //create player UI
            playerUIInstance = Instantiate(playerUIPrefab);
            playerUIInstance.name = playerUIPrefab.name;
            GetComponent<Player>().PlayerSetup();
            objText = GameObject.Find("ObjectiveText").GetComponent<Text>();
            levelManager = GameObject.Find("_LevelMAnager");
            levelManager.GetComponent<Objective>().SetObjective(objText);
        }
        
    }

    void SetLayerRecursively (GameObject obj, int newLayer)
    {
        obj.layer = newLayer;

        foreach(Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        string netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player player = GetComponent<Player>();

        GameManager.RegisterPlayer(netID, player);
    }

    void AssignRemotePlayer()
    {
        gameObject.layer = remoteLayerNumber;
    }

    void DisableComponents()
    {
        Destroy(playerUIInstance);
        for (int i = 0; i < componentsToDisable.Length; i++)
            componentsToDisable[i].enabled = false;
    }

    void OnDisable()
    {
        if (isLocalPlayer)
        {
            if (sceneCamera != null)
                sceneCamera.gameObject.SetActive(true);
        }
        GameManager.UnRegisterPlayer(transform.name);
        
    }
    
}
