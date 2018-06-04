using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour {

    public int EnemyMaxHealth;
    public int CurrentHealth;

	// Use this for initialization
	void Start () {
        CurrentHealth = EnemyMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if(CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
		
	}
    //public void HurtEnemy



}
