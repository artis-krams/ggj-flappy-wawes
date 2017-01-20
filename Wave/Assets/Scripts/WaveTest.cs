
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
	private int i;
	public GameObject[] pickuplist;
	public GameObject pickup1;
	public GameObject pickup2;
	public GameObject pickup3;
	public GameObject camera;
	public GameObject spawner;
	public GameObject destroyer;
	private int spaceDown = 0;
	// Use this for initialization
	void Start () {

		pickuplist = new GameObject[pickupcount];

		while (i < pickupcount) {
			pickuplist [i] = Instantiate (pickup1, new Vector3 (spawner.transform.position.x, 0, 0), Quaternion.identity);
			i++;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {

		camera.transform.position = new Vector3 (player.transform.position.x, 0, -10);
		//camera.transform.position.y = player.transform.position.y;

	
		player.transform.Translate (new Vector3 (speed, 0, 0));

		if (Input.GetKeyDown("space")==true) //risky iet uz hang

		{
			spaceDown = 1;
		}

		if (Input.GetKeyUp ("space") == true) {
			spaceDown = 0;
		}

		if (spaceDown == 1) {
			print ("space pressed");
			currentwavestrenght = currentwavestrenght + waveincrease;
		}

		if (spaceDown == 0) {
			print ("space not pressed");
			if (currentwavestrenght > 0) {
				currentwavestrenght = currentwavestrenght - waveincrease;
			} else {
				currentwavestrenght = 0;
			}
		}

	}
}
