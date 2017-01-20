using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTest : MonoBehaviour {

	public GameObject player;
	public float speed;
	public float score;
	public float waveincrease;
	public float currentwavestrenght;
	public int pickupcount;
	public GameObject[] pickuplist;
	public GameObject pickup1;
	public GameObject pickup2;
	public GameObject pickup3;
	// Use this for initialization
	void Start () {

		pickuplist = new GameObject[pickupcount];


		pickuplist[0] = Instantiate (pickup1, new Vector3(0,0,0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {

		player.transform.Translate (new Vector3 (speed, 0, 0));



		while (Input.GetKeyDown("space")==true) //risky iet uz hang

		{
			print ("space pressed");
			currentwavestrenght = currentwavestrenght + waveincrease;
		}
		
		
	}
}
