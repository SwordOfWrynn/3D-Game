using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlockObject : MonoBehaviour {

    public GameObject toBeDestroyed;

	// Use this for initialization
	void Start () {
		if(toBeDestroyed == null)
        {
            //Debug.LogError("The toBeDestroyed variable needs a reference!");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider colInfo)
    {
        if (colInfo.gameObject.tag == "Player")
        {
            GetComponent<DialogueTrigger>().TriggerDialogue();
            Destroy(toBeDestroyed);
        }
    }
}
