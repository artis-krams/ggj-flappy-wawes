
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTest : MonoBehaviour {

	public GameObject player;
	public float speed;
	public float score;
	public float waveincrease;
	public float currentwavestrenght;
	public float frequency;  // Speed of sine movement
	public float magnitude;   // Size of sine movement
	public float period;
	public int pickupcount;
	private int i;
	public GameObject pickup1;
	public GameObject pickup2;
	public GameObject pickup3;
	public GameObject camera;
	public GameObject spawner;
	public GameObject destroyer;
	public GameObject wall1;
	public GameObject wall2;

	private float nextActionTime = 0.0f;
	private int spaceDown = 0;
	private Vector3 axis;
	private Vector3 pos;
	// Use this for initialization
	void Start () {

		pos = player.transform.position;
		axis = player.transform.up;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {

		camera.transform.position = new Vector3 (player.transform.position.x + 2, 0, -10);
		//camera.transform.position.y = player.transform.position.y;

		pos += player.transform.transform.right * Time.deltaTime * speed;
//		player.transform.Translate (new Vector3 (speed, 0, 0));
		player.transform.position = pos + axis * Mathf.Sin (Time.time * frequency) * currentwavestrenght;
		spawner.transform.position = new Vector3 (player.transform.position.x + 25, spawner.transform.position.y, 0);
		destroyer.transform.position = new Vector3 (player.transform.position.x - 10, destroyer.transform.position.y, 0);
		wall1.transform.position = new Vector3 (player.transform.position.x, wall1.transform.position.y, 0);
		wall2.transform.position = new Vector3 (player.transform.position.x, wall2.transform.position.y, 0);

		if (Time.time > nextActionTime ) {
			nextActionTime += period;

			int sw = Random.Range (0, 3);
			switch (sw) {
			case 0:
				Instantiate (pickup1, new Vector3 (spawner.transform.position.x, Random.Range (8.0f, -8.0f), 0), Quaternion.identity);
				break;
			case 1:
				Instantiate (pickup2, new Vector3 (spawner.transform.position.x, Random.Range (8.0f, -8.0f), 0), Quaternion.identity);
				break;
			case 2:
				Instantiate (pickup3, new Vector3 (spawner.transform.position.x, Random.Range (8.0f, -8.0f), 0), Quaternion.identity);
				break;
			}

		}
//		player.transform.position = Vector3.MoveTowards(transform.position, new Vector3 (transform.position.x+1,currentwavestrenght,0), 10);
		if (Input.GetKeyDown("space")==true) //risky iet uz hang

		{
			spaceDown = 1;
		}

		if (Input.GetKeyUp ("space") == true) {
			spaceDown = 0;
		}

		if (spaceDown == 1) {
			currentwavestrenght = currentwavestrenght + waveincrease;
		}

		if (spaceDown == 0) {
			if (currentwavestrenght > 0) {
				currentwavestrenght = currentwavestrenght - (3 * waveincrease);
			} else {
				currentwavestrenght = 0;
			}
		}

	}
}
