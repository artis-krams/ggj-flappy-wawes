using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {
	

	void OnCollisionEnter(Collision collision) 
	{
		//print (collision);

		if (collision.collider.name=="wall"){
			print("Collision wall");
			this.gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
		};
	}

}
