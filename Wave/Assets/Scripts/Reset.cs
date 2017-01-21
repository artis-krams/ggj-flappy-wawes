using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {
	public GameObject managerR;
	private WaveTest wtest;

	void Start() {
		wtest = managerR.GetComponent<WaveTest> ();

	}

	void OnCollisionEnter(Collision collision) 
	{
		if (collision.collider.name=="wall"){
//			this.gameObject.transform.position = new Vector3 (transform.position.x, 0, 0);
			wtest.currentwavestrenght = 0;
		};
	}

}
