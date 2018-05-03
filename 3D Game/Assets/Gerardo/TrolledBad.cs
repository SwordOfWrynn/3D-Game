using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrolledBad : MonoBehaviour {

	/*we created a new function evr object with this script attached to it
	 * collides with another object this function recieves a variable of type collision named myCollisionInfo that acts like and incident
	 */
	void OnCollisionEnter(Collision myCollisionInfo)
	{
		//we debug.log the name of the object we
		//ran into,that triggered the collision
		Debug.Log (myCollisionInfo.gameObject.name); 
		if (myCollisionInfo.gameObject.name == "Door") 
		{
			//load next level
			SceneManager.LoadScene("Lvl4");
			//this code will reload the current scene
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);


		}
	}

}