using UnityEngine;

public class GunScript : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;
	
	public camera fpsCam;

	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown ("Fire1")) 
		{
			Shoot ();
		}
	
	}

	void Shoot()
	{
		RaycastHit hit;
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.trasform.forward, out hit, range)) 
		{
			Debug.Log (hit.transform.name);
		}
	}
}
