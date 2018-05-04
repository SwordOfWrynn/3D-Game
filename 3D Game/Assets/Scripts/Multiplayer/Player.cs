using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;


public class Player : NetworkBehaviour {

    [SyncVar]
    private bool _isDead = false;
    public bool isDead
    {
        get { return _isDead; }
        protected set { _isDead = value; }
    }
    [SerializeField]
    private Behaviour[] disableOnDeath;
    private bool[] wasEnabled;

    private Text healthText;
    [SerializeField]
    private int maxHealth = 100;
    //when variable changes automatically sent to clients
    [SyncVar]
    private int currentHealth;
    private GameObject levelManager;
    private Text objText;

    // Use this for initialization
    public void PlayerSetup() {

        CmdBroadcastNewPlayerSetup();

        objText = GameObject.Find("ObjectiveText").GetComponent<Text>();
        levelManager = GameObject.Find("_LevelManager");
        levelManager.GetComponent<Objective>().SetObjective(objText);
    }

    [Command]
    private void CmdBroadcastNewPlayerSetup()
    {
        RpcSetupPlayerOnAllClients();
    }

    [ClientRpc]
    private void RpcSetupPlayerOnAllClients ()
    {
        wasEnabled = new bool[disableOnDeath.Length];
        for (int i = 0; i < wasEnabled.Length; i++)
        {
            wasEnabled[i] = disableOnDeath[i].enabled;
        }

        SetDefaults();
    }

    private void Update()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetKeyDown(KeyCode.K))
        {
            RpcTakeDamage(99999);
            Debug.Log("it's over 9000!!!");
        }
        if (healthText == null)
        {
            healthText = GameObject.Find("healthText").GetComponent<Text>();
        }
        healthText.text = "Health: " + currentHealth;
    }

    [ClientRpc]
    public void RpcTakeDamage (int amount)
    {
        if (isDead)
            return;
        currentHealth -= amount;
        Debug.Log(transform.name + " now has " + currentHealth + " health");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        for (int i = 0; i < disableOnDeath.Length; i++)
        {
            disableOnDeath[i].enabled = false;
        }
        Collider col = GetComponent<Collider>();
        if (col != null)
            col.enabled = false;
        Debug.Log(transform.name + " is dead");
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(GameManager.instance.matchsettings.respawnTime);

        SetDefaults();
        Transform spawnPoint= NetworkManager.singleton.GetStartPosition();
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;


        Debug.Log(transform.name + " respawned");
    }

    public void SetDefaults()
    {
        isDead = false;
        currentHealth = maxHealth;

        for (int i = 0; i < disableOnDeath.Length; i++)
        {
            disableOnDeath[i].enabled = wasEnabled[i];
        }
        //colliders can't be put in behavior, so it is set by itself
        Collider col = GetComponent<Collider>();
        if (col != null)
            col.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Door")
        {
            levelManager.GetComponent<NextLevel>().LoadNextLevel();
        }
    }

}
