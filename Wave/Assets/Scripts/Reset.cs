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
		if (collision.collider.name=="wall") {
			wtest.SlowDown ();
		};

		if (collision.collider.name=="Destroyer") {
			wtest.gameOver = true;
		};
	}

}
