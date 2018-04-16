using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componentsToDisable;
    [SerializeField]
    private int remoteLayerNumber = 10;

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
        }

        RegisterPlayer();
    }

    void RegisterPlayer()
    {
        string ID = "Player " + GetComponent<NetworkIdentity>().netId;
        transform.name = ID;
    }

    void AssignRemotePlayer()
    {
        gameObject.layer = remoteLayerNumber;
    }

    void DisableComponents()
    {
        for (int i = 0; i < componentsToDisable.Length; i++)
            componentsToDisable[i].enabled = false;
    }

    void OnDisable()
    {
        if (sceneCamera != null)
            sceneCamera.gameObject.SetActive(true);
    }

}
