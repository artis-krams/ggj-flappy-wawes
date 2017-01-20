using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollision : MonoBehaviour {

	void OnCollisionEnter(Collision collision) 
	{
		print (collision);
		//if (collision.collider.tag=="Player")
		if (collision.collider.name=="Player"){
			print("Collision");
			Destroy (gameObject);
		};
		if (collision.collider.name=="Destroyer"){
			print("Collision");
			Destroy (gameObject);
		};

	}

}
